using System;
using System.Linq;
using System.Linq.Expressions;

namespace G4.Core.Infrastructure
{
    /// <summary>
    /// Read-only repository interface
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class,IEntityKey<TKey>
    {
        /// <summary>
        /// All entities
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Find entity by expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns><see cref="TEntity"/></returns>
        TEntity Get(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Filter a collection of entities by expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Find single <see cref="TEntity"/> by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><see cref="TEntity"/></returns>
        TEntity FindBy(TKey id);
    }
}