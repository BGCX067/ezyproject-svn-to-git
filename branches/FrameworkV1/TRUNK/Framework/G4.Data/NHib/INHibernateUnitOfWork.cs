using G4.Core.Infrastructure;
using NHibernate;

namespace G4.Data.NHib
{
    public interface INHibernateUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
    }
}