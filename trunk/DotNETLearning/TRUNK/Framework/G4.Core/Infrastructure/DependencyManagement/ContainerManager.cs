using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace G4.Core.Infrastructure.DependencyManagement
{
    public class ContainerManager
    {
        private readonly IContainer _container;

        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public IContainer Container
        {
            get
            {
                return _container;
            }
        }


    
    }
}
