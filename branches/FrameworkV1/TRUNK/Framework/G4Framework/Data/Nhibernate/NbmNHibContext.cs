using NHibernate;
using NHibernate.Cfg;

namespace G4Framework.Data.Nhibernate
{
    public sealed class NbmNHibContext:NHibContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HbmNHibContext"/> class.
        /// Since you do not provide an assembly that contains the mappings,
        /// you have to provide these via configuration of mapping-resources.
        /// </summary>
        public NbmNHibContext():this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibContext"/> class.
        /// </summary>
        /// <param name="assemblyName">The Name of the Assembly containing the mappings.</param>
        public NbmNHibContext(string assemblyName)
        {
            SessionFactory = CreateSessionFactory(assemblyName);
        }

        /// <summary>
        /// Creates and returns a session factory.
        /// </summary>
        /// <param name="assemblyName">Optional Name of the assembly that contains the mappings.</param>
        /// <returns></returns>
        private ISessionFactory CreateSessionFactory(string assemblyName)
        {
            var cfg = new Configuration();
            cfg.Configure();

            if (!string.IsNullOrEmpty(assemblyName))
                cfg.AddAssembly(assemblyName);
            return cfg.BuildSessionFactory();
        }
    }
}