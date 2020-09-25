using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.MediatR
{
    /// <summary>
    /// MediatR Config
    /// </summary>
    public static class MediatRConfig
    {
        /// <summary>
        /// Add MediatR
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
