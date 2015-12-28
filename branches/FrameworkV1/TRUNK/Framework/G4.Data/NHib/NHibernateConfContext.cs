using System.Reflection;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
namespace G4.Data.NHib
{
    public class NHibernateConfContext : INHibernateContext
    {
/*        private readonly Assembly _assembly;
        private readonly ObjectRelationalMapper orm;

        public NHibernateConfContext(Assembly assembly)
        {
            this._assembly = assembly;
        }

        public INHibernateUnitOfWork CreateUnitOfWork()
        {
            
        }

        private ISessionFactory CreateSessionFactory()
        {
            var orm = new ObjectRelationalMapper()
        }*/
        public INHibernateUnitOfWork CreateUnitOfWork()
        {
            throw new System.NotImplementedException();
        }
    }
}