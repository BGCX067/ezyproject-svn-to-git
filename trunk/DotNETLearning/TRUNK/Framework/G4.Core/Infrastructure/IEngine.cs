using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using G4.Core.Infrastructure.DependencyManagement;

namespace G4.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the 
    /// various services composing the engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Ioc container manager
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize modules
        /// </summary>
        /// <param name="modules"></param>
        void Initialize(params Module[] modules);

        T Resolve<T>() where T : class;

        T[] ResolveAll<T>();
    }
}
