using System;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.IdentityServer4
{
    /// <summary>
    /// IdentityServer4 Configuration
    /// </summary>
    public static class Ids4Config
    {
        /// <summary>
        /// Add Config
        /// </summary>
        /// <param name="services"></param>
        public static void AddIdentityServer(this IServiceCollection services)
        {
            services.AddIdentityServer();
        }
    }
}
