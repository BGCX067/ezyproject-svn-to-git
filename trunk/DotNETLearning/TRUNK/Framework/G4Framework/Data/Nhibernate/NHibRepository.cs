using System;
using System.Linq;
using System.Linq.Expressions;
using G4Framework.Infrastructure;
using StructureMap;

namespace G4Framework.Data.Nhibernate
{
    public abstract class NHibRepository<T> : IRepository<T> where T:class 
    {
        protected NHibContext Context { get; private set; }

        //protected NHibRepository(NHibContext context)
        //{
        //    this.Context = context;
        //}

        protected NHibRepository()
        {
            //this.Context = ObjectFactory.GetInstance<NHibContext>();
        }

        public void Insert(T item)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                uow.Insert(item);
                uow.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                uow.Update(item);
                uow.SaveChanges();
            }
        }

        public void Delete(T item)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                uow.Delete(item);
                uow.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                return uow.GetItemBy(query);
            }
        }

        public T Load<TId>(TId id)
        {
            T result;
            using (var uow = Context.CreateUnitOfWork())
            {
                result = uow.LoadItemById<T,TId>(id);
            }

            return result;
        }

        public IQueryable<T> All()
        {
            IQueryable<T> result;

            using (var uow = Context.CreateUnitOfWork())
            {
                result = uow.GetList<T>();
            }

            return result;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> query)
        {
            IQueryable<T> result;
            using (var uow = Context.CreateUnitOfWork())
            {
                result = uow.GetListBy(query);
            }

            return result;
        }
    }
}