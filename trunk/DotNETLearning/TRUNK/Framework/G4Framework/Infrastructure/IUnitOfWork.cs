using System;
using NHibernate;

namespace G4Framework.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void RollBack();
        void Commit();
        ISession Session { get; }
    }
}