namespace G4.Core.Infrastructure
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void RollBack();
        void Commit();
    }
}