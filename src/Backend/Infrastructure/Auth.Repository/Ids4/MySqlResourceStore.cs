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
                apiResources = (await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.ApiResource>(new List<Condition>
                {
                    new Condition
                    {
                        Name = "Name",
                        Value = apiResourceNames,
                        Type = ConditionalType.In
                    }
                }));
            }

            return _mapper.Map<IEnumerable<ApiResource>>(apiResources);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
