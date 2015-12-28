using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G4.Core.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace G4.Data.NHDataProvider
{
    public class NHRepository<TKey,T> : IReadOnlyRepository<TKey,T>,IPersistRepository<TKey,T> where T: class, IEntityKey<TKey>
    {

        #region Private Members
        private ISession _session; 
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="NHRepository&lt;TKey, T&gt;"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public NHRepository(ISession session)
        {
            this._session = session;
        }                
        #endregion

        #region IPersistRepository<T> Members

        public bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                _session.Save(entity);

            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(TKey id)
        {
            T entity = FindBy(id);

            if (entity != null)
                Delete(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                _session.Delete(entity);

            return true;
        }

        #endregion

        #region IReadOnlyRepository<TKey,T> Members

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return Find(expression).SingleOrDefault();
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All().Where(expression);
        }

        public T FindBy(TKey id)
        {
            return _session.Get<T>(id);
        }

        #endregion

    }
}
