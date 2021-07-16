using System;
using System.Collections.Generic;
using System.Linq;
using Auth.Utility;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.IoC
{
    /// <summary>
    /// AspNet Core DI Config
    /// </summary>
    public static class IocConfig
    {
        /// <summary>
        /// AspNet Core DI Extension
        /// </summary>
        /// <param name="services"></param>
        public static void AddIocConfiguration(this IServiceCollection services)
        {
            #region MediatR注入

            // MediatR 注入
            services.AddTransient<IMediator, Mediator>();

            // MediatR Handler服务程序注入
            IEnumerable<Type> handlers = AssemblyUtility.GetAssembly("Auth.Application")
                .ExportedTypes
                .Where(s => s.GetInterfaces()
                    .Where(x => x.Namespace.Equals("MediatR")
                        && x.Name.StartsWith("IRequestHandler"))
                    .Any());

            // 遍历Handler类并注入
            foreach(var handler in handlers)
            {
                var requests = handler.GetInterfaces()
                    .Where(s => s.Namespace.Equals("MediatR")
                        && s.Name.StartsWith("IRequestHandler"));

                foreach(var request in requests)
                {
                    services.AddTransient(request, handler);
                }
            }

            #endregion

            #region 批量注入仓储服务

            // 仓储类
            IEnumerable<Type> repositories = AssemblyUtility.GetAssembly("Auth.Repository")
                .ExportedTypes
                .Where(s => s.IsClass && !s.IsSealed);

            // 仓储类批量注入
            foreach(var repository in repositories)
            {
                services.AddSingleton(repository.GetInterfaces().Where(s => s.Name.EndsWith(repository.Name)).FirstOrDefault() ,repository);
            }

            #endregion
        }
    }
}
