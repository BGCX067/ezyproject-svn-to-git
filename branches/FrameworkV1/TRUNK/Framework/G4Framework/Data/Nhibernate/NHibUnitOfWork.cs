using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Linq;

namespace G4Framework.Data.Nhibernate
{
    public class NHibUnitOfWork : IDisposable
    {
        private readonly object _lock = new object();

        /// <summary>
        /// Indicates if there are any un-flushed changes.
        /// </summary>
        public bool HasChanges { get; set; }

        /// <summary>
        /// Original NHibernate session that is wrapped.
        /// </summary>
        private ISession InnerSession { get; set; }

        public NHibUnitOfWork(ISession session)
        {
            this.HasChanges = false;
            this.InnerSession = session;
            this.InnerSession.FlushMode = FlushMode.Never;
        }

        /// <summary>
        /// Allows an <see cref="T:System.Object"/> to attempt to free resources and perform other cleanup operations before the <see cref="T:System.Object"/> is reclaimed by garbage collection.
        /// </summary>
        ~NHibUnitOfWork()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                this.FreeManagedResources();
        }

        public IQuery CreateQuery(string queryString)
        {
            return this.InnerSession.CreateQuery(queryString);
        }

        public ICriteria CreateCriteria<T>() where T : class
        {
            return this.InnerSession.CreateCriteria<T>();
        }

        public TReturn GetItemById<TReturn, TId>(TId id)
        {
            return this.InnerSession.Get<TReturn>(id);
        }

        public T GetItemBy<T>(Expression<Func<T, bool>> query)
        {
            return this.InnerSession.Query<T>().SingleOrDefault(query);
        }

        public TReturn LoadItemById<TReturn, TId>(TId id)
        {
            return this.InnerSession.Load<TReturn>(id);
        }

        public T GetItemByCriterions<T>(params ICriterion[] criterions)
        {
            return AddCriterions(this.InnerSession.CreateCriteria(typeof (T)), criterions).UniqueResult<T>();
        }

        public IQueryable<T> GetList<T>()
        {
            return this.InnerSession.Query<T>();
        }

        public IQueryable<T> GetListBy<T>(Expression<Func<T, bool>>  query)
        {
            return this.InnerSession.Query<T>().Where(query);
        }

        public IList<T> GetListByCriterions<T>(params ICriterion[] criterions)
        {
            ICriteria criteria = AddCriterions(this.InnerSession.CreateCriteria(typeof (T)), criterions);
            IList<T> result = criteria.List<T>();

            return result;
        }

        /// <summary>
        ///  Deletes item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Delete<T>(T obj)
        {
            this.InnerSession.Delete(obj);
            this.HasChanges = true;
        }

        /// <summary>
        /// Deletes item by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        public void Delete<T, TId>(TId id)
        {
            this.Delete(GetItemById<T, TId>(id));
            this.HasChanges = true;
        }

        public void Delete(string query)
        {
            this.InnerSession.Delete(query);
            this.HasChanges = true;
        }

        public void Insert<T>(T obj)
        {
            this.InnerSession.Save(obj);
            this.HasChanges = true;
        }

        public void Update<T>(T obj)
        {
            this.InnerSession.Update(obj);
            this.HasChanges = true;
        }

        public void Clear()
        {
            lock (this._lock)
            {
                this.InnerSession.Clear();
                this.HasChanges = false;
            }
        }

        public void SaveChanges()
        {
            if (!this.HasChanges) return;

            lock (this._lock)
            {
                using (InnerSession.BeginTransaction())
                {
                    //this.InnerSession.Flush();
                    this.HasChanges = false;
                    InnerSession.Transaction.Commit();
                }
            }
        }

        #region Private methods

        private static ICriteria AddCriterions(ICriteria criteria, ICriterion[] criterions)
        {
            if (criterions != null)
                for (int i = 0; i < criterions.Length; i++)
                {
                    criteria = criteria.Add(criterions[i]);
                }

            return criteria;
        }

        private void FreeManagedResources()
        {
            if (this.InnerSession == null) return;

            this.InnerSession.Close();
            this.InnerSession.Dispose();
            this.InnerSession = null;
        }

        #endregion
    }
}