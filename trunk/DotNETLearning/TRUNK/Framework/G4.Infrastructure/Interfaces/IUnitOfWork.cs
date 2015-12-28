namespace G4.Infrastructure.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void RollBack();
        void Commit();
    }
}