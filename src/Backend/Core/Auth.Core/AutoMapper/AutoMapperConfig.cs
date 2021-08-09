using System;
using System.Collections.Generic;
using Auth.Application.Handlers.Base;
using Auth.Core.AutoMapper.Ids4;
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
            // Between IdentityServer4.Models and entity
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile<ClientMapperProfile>())
                .CreateMapper());

            // Between entity and dto
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile<AutoMapperProfile>())
                .CreateMapper());
        }
    }
}
