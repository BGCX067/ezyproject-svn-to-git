using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using G4.Core.Infrastructure;
using NHibernate.Linq;
using StructureMap;

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
            Context = ObjectFactory.GetInstance<INHibernateContext>();
            _unitOfWork = Context.CreateUnitOfWork();
        }

        public void Insert(T item)
        {
            _unitOfWork.Session.Save(item);
        }

        public void Update(T item)
        {
            _unitOfWork.Session.Update(item);
        }

        public void Delete(T item)
        {
            _unitOfWork.Session.Delete(item);
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            return _unitOfWork.Session.Query<T>().SingleOrDefault(query);
        }

        public virtual T Load<TId>(TId id)
        {
            return _unitOfWork.Session.Load<T>(id);
        }

        public IQueryable<T> All()
        {
            return _unitOfWork.Session.Query<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query)
        {
            return _unitOfWork.Session.Query<T>().Where(query);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query, int pageIndex, int pageSize, out long total)
        {
            return Find(query, string.Empty, OrderByDirection.Ascending, pageIndex, pageSize, out total);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query, string sortColumnName,
                                  OrderByDirection orderByDirection, int pageIndex, int pageSize, out long total)
        {
            IQueryable<T> totalItems = All();
            total = totalItems.LongCount();

            IQueryable<T> queryable = All().Where(query);
            queryable = AddDynamicOrderBy(queryable, sortColumnName, orderByDirection);
            return queryable.Skip((pageIndex - 1)*pageSize).Take(pageSize);
        }

        #region Private Methods

        private IQueryable<T> AddDynamicOrderBy(IQueryable<T> query, string sortColumnName,
                                                OrderByDirection orderByDirection)
        {
#if NET40
            if(!string.IsNullOrWhiteSpace(sortColumnName))
#elif NET35
            if(!sortColumnName.IsNullOrWhiteSpace())
#endif
            {
                query =
                    query.OrderBy(string.Format("{0} {1}", sortColumnName,
                                                orderByDirection == OrderByDirection.Descending ? "DESC" : "ASC"));
            }

            return query;
        }

        #endregion

        public void Save()
        {
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
            //finally
            //{
            //    this._unitOfWork.Dispose();
            //}
        }
    }
}