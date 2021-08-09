using System;
using AutoMapper;
using IdentityServer4.Models;

namespace Auth.Core.AutoMapper.Ids4
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Entity.Ids4Entity.Client, Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srcs => srcs != null))
                .ReverseMap();
        }
    }
}
