using System;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Module = Autofac.Module;

namespace Auth.Core.Autofac
{
    public class AutofacModule : Module
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.StartsWith("Auth"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(new Assembly[] {
            //    GetAssembly("Auth.IRepository"),
            //    GetAssembly("Auth.Repository")
            //}).AsImplementedInterfaces()
            //.InstancePerLifetimeScope();
        }

        /// <summary>
        /// Get Assembly
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        protected static Assembly GetAssembly(string assemblyName)
        {
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
