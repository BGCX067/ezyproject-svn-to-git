namespace G4Framework.Data.Nhibernate
{
    using Infrastructure;
    using NHibernate;
    using NHibernate.Cfg;
    
    public class NHibernateHbmContext : INHibernateContext
    {
        private readonly string _assemblyName;

        public NHibernateHbmContext(string assemblyName)
        {
            this._assemblyName = assemblyName;
        }

        public IUnitOfWork CreateUnitOfWork()
        {            
            return new UnitOfWork(CreateSessionFactory());
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