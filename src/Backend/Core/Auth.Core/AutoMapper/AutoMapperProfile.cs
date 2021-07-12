using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using AutoMapper;

namespace Auth.Core.AutoMapper
{
    /// <summary>
    /// AutoMapper Profile
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapperProfile()
        {
            List<Type> entities = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + "Auth.Entity.dll").DefinedTypes.Select(s => s.AsType()).ToList();
            List<Type> dtos = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + "Auth.Dtos.dll").DefinedTypes.Select(s => s.AsType()).ToList();

            if (entities.Any() && dtos.Any())
            {
                entities.ForEach(entity =>
                {
                    dtos.ForEach(dto =>
                    {
                        if (dto.Name.EndsWith($"{entity.Name}Dto"))
                        {
                            CreateMap(entity, dto).ReverseMap();
                        }
                    });
                });
            }
        }
    }
}
