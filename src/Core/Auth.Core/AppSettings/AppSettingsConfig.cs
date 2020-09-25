using System;
using Auth.Repository.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.AppSettings
{
    /// <summary>
    /// AppSettings Config
    /// </summary>
    public static class AppSettingsConfig
    {
        /// <summary>
        /// AppSettings Extension
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
