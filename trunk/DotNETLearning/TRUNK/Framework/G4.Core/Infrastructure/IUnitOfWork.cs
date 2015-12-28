using System;

namespace G4.Core.Infrastructure
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Rolls back.
        /// </summary>
        void RollBack();

        /// <summary>
        /// Commits.
        /// </summary>
        void Commit();
    }
}