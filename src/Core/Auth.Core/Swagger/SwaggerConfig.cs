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
        /// Add Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IApplicationBuilder builder, IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
            });

            builder
                .UseSwagger()
                .UseSwaggerUI(config => {
                    config.RoutePrefix = "swagger/ui";
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", title);
                });
        }
    }
}
