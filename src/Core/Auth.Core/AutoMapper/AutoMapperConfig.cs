using System;
using System.Collections.Generic;
using Auth.Application.Handlers.Base;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.AutoMapper
{
    /// <summary>
    /// AutoMapper Config
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// AutoMapper Extension
        /// </summary>
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile<AutoMapperProfile>())
                .CreateMapper());
        }
    }
}
