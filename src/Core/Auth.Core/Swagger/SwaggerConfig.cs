using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Auth.Core.Swagger
{
    /// <summary>
    /// Swaggger Config
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Title
        /// </summary>
        private const string title = "基础数据认证平台";

        /// <summary>
        /// Add SwaggerGen
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerGenConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
            });
        }

        /// <summary>
        /// Add SwaggerUI
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwaggerUIConfiguration(this IApplicationBuilder builder)
        {
            builder
                .UseSwagger()
                .UseSwaggerUI(config => {
                    config.RoutePrefix = "swagger/ui";
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", title);
                });
        }
    }
}
