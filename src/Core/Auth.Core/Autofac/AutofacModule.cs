using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Auth.Core.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.StartsWith("Auth"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
