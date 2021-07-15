using System.Reflection;
using Auth.Core.AppSettings;
using Auth.Core.AutoMapper;
using Auth.Core.DI;
using Auth.Core.Swagger;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Auth.UI.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Environment = env;
        }

        public IConfiguration Configuration { get; private set; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddPolicy("auth-admin",
                option => option
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    )
            );
            services.AddControllers().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.AddAppSettingsConfiguration(Configuration);
            services.AddAutoMapperConfiguration();
            services.AddSwaggerGenConfiguration();
            services.AddIocConfiguration();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddSwaggerUIConfiguration();

            app.UseRouting();

            app.UseCors("auth-admin");

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
