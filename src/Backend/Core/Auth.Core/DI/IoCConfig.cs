using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Auth.Application.Commands.Base.User;
using Auth.Application.Handlers.Base;
using Auth.Core.Utility;
using Auth.IRepository;
using Auth.IRepository.IBase;
using Auth.Repository;
using Auth.Repository.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.DI
{
    /// <summary>
    /// AspNet Core DI Config
    /// </summary>
    public static class IoCConfig
    {
        /// <summary>
        /// AspNet Core DI Extension
        /// </summary>
        /// <param name="services"></param>
        public static void AddIoCConfiguration(this IServiceCollection services)
        {
            #region MediatR注入

            // MediatR 注入
            services.AddTransient<IMediator, Mediator>();

            // MediatR Handler服务程序注入
            IEnumerable<Type> handlers = BaseUtility.GetAssembly("Auth.Application")
                .ExportedTypes
                .Where(s => s.GetInterfaces()
                    .Where(x => x.IsClass
                        && x.Namespace.Equals("MediatR")
                        && x.Name.StartsWith("IRequestHandler"))
                    .Any());

            // 遍历Handler类并注入
            foreach(var handler in handlers)
            {
                services.AddTransient(handler.GetInterfaces()
                    .Where(s => s.Namespace.Equals("MediatR")
                        && s.Name.StartsWith("IRequestHandler"))
                    .FirstOrDefault(), handler);
            }

            #endregion

            #region 批量注入仓储服务

            // UnifOfWork
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));

            // 仓储类
            IEnumerable<Type> repositories = BaseUtility.GetAssembly("Auth.Repository")
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
