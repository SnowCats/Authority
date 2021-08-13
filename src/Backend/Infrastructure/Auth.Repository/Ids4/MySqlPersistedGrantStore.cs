using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.IRepository;
using Auth.IRepository.IIds4;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Auth.Repository.Ids4
{
    public class MySqlPersistedGrantStore : RepositoryBase, IMySqlPersistedGrantStore
    {
        private readonly IDbContext _dbContext;

        public MySqlPersistedGrantStore(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            throw new NotImplementedException();
        }
    }
}
