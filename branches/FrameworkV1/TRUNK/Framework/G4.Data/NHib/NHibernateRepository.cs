using System;
using System.Linq;
using System.Linq.Expressions;
using G4.Core.Infrastructure;
using NHibernate.Linq;
using StructureMap;
using System.Linq.Dynamic;
#if NET35
using G4.Core.Extensions;
#endif

namespace G4.Data.NHib
{
    /// <summary>
    /// The different order by directions when retrieving data
    /// </summary>
    public enum OrderByDirection
    {
        Ascending,
        Descending
    }

    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        protected INHibernateContext Context { get; private set; }
        private readonly INHibernateUnitOfWork _unitOfWork;

        public NHibernateRepository()
        {
            this.Context = ObjectFactory.GetInstance<INHibernateContext>();
            //this.Context = EngineContext.Resolve<INHibernateContext>();
            this._unitOfWork = this.Context.CreateUnitOfWork();
        }

        public void Insert(T item)
        {
            this._unitOfWork.Session.Save(item);
        }

        public void Update(T item)
        {
            this._unitOfWork.Session.Update(item);
        }

        public void Delete(T item)
        {
            this._unitOfWork.Session.Delete(item);
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            return this._unitOfWork.Session.Query<T>().SingleOrDefault(query);
        }

        public virtual T Load<TId>(TId id)
        {
            return this._unitOfWork.Session.Load<T>(id);
        }

        public IQueryable<T> All()
        {
            return this._unitOfWork.Session.Query<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query)
        {
            return this._unitOfWork.Session.Query<T>().Where(query);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query, int pageIndex, int pageSize, out long total)
        {           
            return Find(query, string.Empty, OrderByDirection.Ascending, pageIndex, pageSize, out total);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query, string sortColumnName, OrderByDirection orderByDirection, int pageIndex, int pageSize, out long total)
        {
            IQueryable<T> totalItems = this.All();
            total = totalItems.LongCount();

            IQueryable<T> queryable = this.All().Where(query);
            queryable = AddDynamicOrderBy(queryable, sortColumnName, orderByDirection);
            return queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        #region Private Methods
        private IQueryable<T> AddDynamicOrderBy(IQueryable<T> query, string sortColumnName, OrderByDirection orderByDirection)
        {
#if NET40
            if(!string.IsNullOrWhiteSpace(sortColumnName))
#elif NET35
            if(!sortColumnName.IsNullOrWhiteSpace())
#endif
            {
                query =
                    query.OrderBy(string.Format("{0} {1}", sortColumnName, orderByDirection == OrderByDirection.Descending ? "DESC" : "ASC"));
            }

            return query;
        } 
        #endregion

        public void Save()
        {
            try
            {
                this._unitOfWork.Commit();
            }
            catch (Exception)
            {
                this._unitOfWork.RollBack();
                throw;
            }
            //finally
            //{
            //    this._unitOfWork.Dispose();
            //}
        }
    }
}