using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.IRepository;
using Auth.IRepository.IIds4;
using Auth.Utility;
using AutoMapper;
using Dapper.Contrib.Plus;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Auth.Repository.Ids4
{
    public class MySqlResourceStore : RepositoryBase, IMySqlResourceStore
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public MySqlResourceStore(IDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            IEnumerable<Entity.Ids4Entity.ApiResource> apiResources = new List<Entity.Ids4Entity.ApiResource>();

            using (_dbContext.InitConnection(RW.R))
            {
                apiResources = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.ApiResource>(new List<Condition>
                {
                    new Condition
                    {
                        Name = nameof(Entity.Ids4Entity.ApiResource.Name),
                        Value = apiResourceNames,
                        Type = ConditionalType.In
                    }
                });
            }

            return _mapper.Map<IEnumerable<ApiResource>>(apiResources);
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Entity.Ids4Entity.ApiResourceScope> apiResourceScopes = new List<Entity.Ids4Entity.ApiResourceScope>();
            IEnumerable<Entity.Ids4Entity.ApiResource> apiResources = new List<Entity.Ids4Entity.ApiResource>();

            using (_dbContext.InitConnection(RW.R))
            {
                apiResourceScopes = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.ApiResourceScope>(new List<Condition>
                {
                    new Condition
                    {
                        Name = nameof(Entity.Ids4Entity.ApiResourceScope.Scope),
                        Value = scopeNames,
                        Type = ConditionalType.In
                    }
                });

                if (apiResourceScopes.Any())
                {
                    apiResources = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.ApiResource>(new List<Condition>
                    {
                        new Condition
                        {
                            Name = nameof(Entity.Ids4Entity.ApiResource.Id),
                            Value = apiResourceScopes.Select(s => s.Id),
                            Type = ConditionalType.In
                        }
                    });
                }
            }

            return _mapper.Map<IEnumerable<ApiResource>>(apiResources);
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Entity.Ids4Entity.ApiScope> apiScopes = new List<Entity.Ids4Entity.ApiScope>();

            using (_dbContext.InitConnection(RW.R))
            {
                apiScopes = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.ApiScope>(new List<Condition>
                {
                    new Condition {
                        Name = nameof(Entity.Ids4Entity.ApiScope.Name),
                        Value = scopeNames,
                        Type = ConditionalType.In
                    }
                });
            }

            return _mapper.Map<IEnumerable<ApiScope>>(apiScopes);
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Entity.Ids4Entity.IdentityResource> identityResources = new List<Entity.Ids4Entity.IdentityResource>();

            using (_dbContext.InitConnection(RW.R))
            {
                identityResources = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.IdentityResource>(new List<Condition>
                {
                    new Condition {
                        Name = nameof(Entity.Ids4Entity.IdentityResource.Name),
                        Value = scopeNames,
                        Type = ConditionalType.In
                    }
                });
            }

            return _mapper.Map<IEnumerable<IdentityResource>>(identityResources);
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            IEnumerable<Entity.Ids4Entity.IdentityResource> identityResources = new List<Entity.Ids4Entity.IdentityResource>();
            IEnumerable<Entity.Ids4Entity.ApiResource> apiResources = new List<Entity.Ids4Entity.ApiResource>();
            IEnumerable<Entity.Ids4Entity.ApiScope> apiScopes = new List<Entity.Ids4Entity.ApiScope>();

            using (_dbContext.InitConnection(RW.R))
            {
                identityResources = await _dbContext.Connection.GetAllAsync<Entity.Ids4Entity.IdentityResource>();
                apiResources = await _dbContext.Connection.GetAllAsync<Entity.Ids4Entity.ApiResource>();
                apiScopes = await _dbContext.Connection.GetAllAsync<Entity.Ids4Entity.ApiScope>();
            }

            Resources resources = new Resources();

            resources.IdentityResources = (ICollection<IdentityResource>)_mapper.Map<IEnumerable<IdentityResource>>(identityResources);
            resources.ApiResources = (ICollection<ApiResource>)_mapper.Map<IEnumerable<ApiResource>>(apiResources);
            resources.ApiScopes = (ICollection<ApiScope>)_mapper.Map<IEnumerable<ApiScope>>(apiScopes);

            return resources;
        }
    }
}
