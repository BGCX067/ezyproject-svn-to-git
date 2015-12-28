using System.Collections.Generic;

namespace G4.Core.Infrastructure
{
    /// <summary>
    /// Persist repository interface
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IPersistRepository<TKey,TEntity> where TEntity : class, IEntityKey<TKey>
    {
        /// <summary>
        /// Adds single <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if all entity is added successful, otherwise<c>false</c>.</returns>
        bool Add(TEntity entity);

        /// <summary>
        /// Adds a collection of <see cref="TEntity"/>.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if all entities are added successful, otherwise<c>false</c>.</returns>
        bool Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates single  <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if all entity is updated successful, otherwise<c>false</c>.</returns>
        bool Update(TEntity entity);

        bool Delete(TKey id);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if entity is deleted successful, otherwise<c>false</c>.</returns>
        bool Delete(TEntity entity);
        
        /// <summary>
        /// Deletes a collection of <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if all entities are deleted successful, otherwise<c>false</c>.</returns>
        bool Delete(IEnumerable<TEntity> entities);
    }
}