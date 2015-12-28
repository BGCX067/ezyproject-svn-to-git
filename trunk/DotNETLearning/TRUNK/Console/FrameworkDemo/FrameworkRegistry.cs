using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using G4.Data.NHib;
using System.Reflection;
using StructureMap.Pipeline;
using G4.Core.Infrastructure;
using G4.Data.NHDataProvider;

namespace FrameworkDemo
{
    public class FrameworkRegistry : Registry
    {
        public FrameworkRegistry()
        {
            //For<INHibernateContext>().CacheBy(StructureMap.InstanceScope.Hybrid).Use(x => new NHibernateFluentContext(Assembly.GetExecutingAssembly()));

            For<INHibernateContext>().LifecycleIs(new HybridLifecycle()).Use<NHibernateFluentContext>().Ctor<Assembly>().Is(Assembly.GetExecutingAssembly());
            For(typeof(IReadOnlyRepository<,>)).LifecycleIs(new HybridLifecycle()).Use(typeof(NHRepository<,>));
            For(typeof(IPersistRepository<,>)).LifecycleIs(new HybridLifecycle()).Use(typeof(NHRepository<,>));
        }
    }
}
