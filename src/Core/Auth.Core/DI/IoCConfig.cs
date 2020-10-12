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

            services.AddTransient<IMediator, Mediator>();

            IEnumerable<Type> applicationTypes = BaseUtility.GetAssembly("Auth.Application").ExportedTypes;
            var handlers = applicationTypes.Where(s => s.GetInterfaces().Where(x => x.Namespace.Equals("MediatR") && x.Name.StartsWith("IRequestHandler")).Any());

            foreach(var handler in handlers)
            {
                services.AddTransient(handler.GetInterfaces().Where(s => s.Namespace.Equals("MediatR") && s.Name.StartsWith("IRequestHandler")).FirstOrDefault(), handler);
            }

            #endregion

            #region 批量DI

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IRepository.IRepository, Repository.Repository>();

            services.AddSingleton<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
