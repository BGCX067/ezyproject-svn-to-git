using G4Framework.Infrastructure;
using NHibernate;

namespace G4Framework.Data.Nhibernate
{
    public interface INHibernateContext
    {        
        IUnitOfWork CreateUnitOfWork();        
    }
}