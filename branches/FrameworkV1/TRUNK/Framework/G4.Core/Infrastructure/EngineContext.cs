using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace G4.Core.Infrastructure
{
    public static class EngineContext
    {
        private static IContainer _container;

        public static void Initialize(params Module[] modules)
        {
            if (modules.Count() == 0)
                throw new ArgumentException("modules");

            ContainerBuilder builder = new ContainerBuilder();
            foreach (Module module in modules)
                builder.RegisterModule(module);
            _container = builder.Build();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
