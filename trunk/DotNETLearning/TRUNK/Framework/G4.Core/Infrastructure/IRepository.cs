namespace G4.Core.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T: class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);

        T Get(Expression<Func<T, bool>> query);        
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, bool>> query);
    }
}