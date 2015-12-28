using System;
using System.Linq;
using System.Linq.Expressions;

namespace G4Framework.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);

        T Get(Expression<Func<T, bool>> query);
        T Load<TId>(TId id);
        IQueryable<T> All();
        IQueryable<T> FindAll(Expression<Func<T, bool>> query);
    }

    
}