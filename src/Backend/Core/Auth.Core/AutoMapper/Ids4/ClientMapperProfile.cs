using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using IdentityServer4.Models;

namespace Auth.Core.AutoMapper.Ids4
{
    /// <summary>
    /// IdentityServer4 MapperProfile
    /// </summary>
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Entity.Ids4Entity.Client, Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srcs => srcs != null))
                .ReverseMap();

            CreateMap<Entity.Ids4Entity.ClientProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Entity.Ids4Entity.ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientClaim, Claim>(MemberList.None)
                .ConstructUsing(src => new Claim(src.Type, src.Value))
                .ReverseMap();

            CreateMap<Entity.Ids4Entity.ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientRedirectUri, string>().
                ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));

            CreateMap<Entity.Ids4Entity.ClientSecret, Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(src => src != null))
                .ReverseMap();
        }
    }
}
