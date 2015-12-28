using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace G4Framework.Data.Nhibernate
{
    /// <summary>
    /// Uses Xml-configuration for setup-config and for mappings is Fluent-NHibernate used.
    /// </summary>
    public sealed class FluentNHibContext : NHibContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentNHibContext"/> class.
        /// </summary>
        /// <param name="assemblyWithMappings">The assembly containing the Fluent mappings.</param>
        public FluentNHibContext(Assembly assemblyWithMappings)
        {
            SessionFactory = CreateSessionFactory(assemblyWithMappings);
        }

        /// <summary>
        /// Creates and returns a session factory.
        /// </summary>
        /// <param name="assemblyWithMappings">The assembly containing the Fluent mappings.</param>
        /// <returns></returns>
        private ISessionFactory CreateSessionFactory(Assembly assemblyWithMappings)
        {
            var cfg = new Configuration();
            cfg = cfg.Configure();
            return
                Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssembly(assemblyWithMappings)).
                    ExposeConfiguration(cfg1 => new SchemaExport(cfg1).Create(false, false)). //Export schema and execute ddl
                    BuildSessionFactory();
        }
    }
}