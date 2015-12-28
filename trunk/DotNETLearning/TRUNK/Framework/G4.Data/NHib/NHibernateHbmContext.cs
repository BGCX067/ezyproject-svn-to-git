using NHibernate;
using NHibernate.Cfg;

namespace G4.Data.NHib
{
    public class NHibernateHbmContext : INHibernateContext
    {
        private readonly string _assemblyName;

        public NHibernateHbmContext(string assemblyName)
        {
            this._assemblyName = assemblyName;
        }

        public INHibernateUnitOfWork CreateUnitOfWork()
        {
            return new NHibernateUnitOfWork(CreateSessionFactory());
        }

        private ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration();
            cfg.Configure();
            //cfg.DataBaseIntegration(x => x.ConnectionString = Setting.ConnectionString.ConnectionString);
            if (!string.IsNullOrEmpty(_assemblyName))
                cfg.AddAssembly(_assemblyName);
            return cfg.BuildSessionFactory();
        }
    }
}