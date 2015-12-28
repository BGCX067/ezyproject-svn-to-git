using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using G4Framework.Infrastructure;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace G4Framework.Data.Nhibernate
{
    public class NHibernateFluentContext : INHibernateContext
    {
        private readonly Assembly _assembly;
        public NHibernateFluentContext(Assembly assemblyWithMappings)
        {
            this._assembly = assemblyWithMappings;
        }
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(CreateSessionFactory());
        }

        public ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration();
            cfg = cfg.Configure();
            return
                Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssembly(_assembly)).
                    //Database(MsSqlConfiguration.MsSql2008.ConnectionString(G4.Core.Config.Setting.ConnectionString.ConnectionString)).
                    ExposeConfiguration(cfg1 => new SchemaExport(cfg1).Create(false, false)). //Export schema and execute ddl
                    BuildSessionFactory();
        }
    }
}