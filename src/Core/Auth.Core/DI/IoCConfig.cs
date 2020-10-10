using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Auth.Application.Handlers.Base;
using Auth.Application.Handlers.Base.UserCommand;
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
            var assembly = BaseUtility.GetAssembly("Auth.Application");

            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<IRequestHandler<CreateUserRequest, Guid>, UserHandler>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IRepository.IRepository, Repository.Repository>();

            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
