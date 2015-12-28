using System;
using System.Linq;
using System.Linq.Expressions;
using G4Framework.Infrastructure;
using StructureMap;

namespace G4Framework.Data.Nhibernate
{
    public class NHibernateRepository<T> : IRepository<T> where T: class
    {
        protected INHibernateContext Context { get; private set; }
        private readonly IUnitOfWork _unitOfWork;

        public NHibernateRepository()
        {
            this.Context = ObjectFactory.GetInstance<INHibernateContext>();
            _unitOfWork = Context.CreateUnitOfWork();
        }
        
        public void Insert(T item)
        {
            _unitOfWork.Session.Save(item);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }

        public T Load<TId>(TId id)
        {
            return _unitOfWork.Session.Load<T>(id);
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {                
                _unitOfWork.RollBack();
            }                        
        }
    }
}