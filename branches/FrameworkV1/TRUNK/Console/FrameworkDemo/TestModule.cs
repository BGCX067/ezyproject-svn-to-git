using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using G4.Data.NHib;
using System.Reflection;

namespace FrameworkDemo
{
    public class TestModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c=>new NHibernateFluentContext(Assembly.GetExecutingAssembly())).As<INHibernateContext>().InstancePerLifetimeScope();
        }
    }
}
