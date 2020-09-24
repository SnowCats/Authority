using System;
using Auth.Repository.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.AppSettings
{
    public static class AppSettingsConfig
    {
        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
