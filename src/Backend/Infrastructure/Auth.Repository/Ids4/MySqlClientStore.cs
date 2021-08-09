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

namespace Auth.Repository.Ids4
{
    /// <summary>
    /// MySqlClientStore
    /// </summary>
    public class MySqlClientStore : RepositoryBase, IMySqlClientStore
    {
        private readonly IDbContext _dbContext;

        private readonly IMapper _mapper;

        public MySqlClientStore(IDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// FindClientByIdAsync
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            using(_dbContext.InitConnection(RW.R))
            {
                var client = await _dbContext.Connection.GetAsync<Entity.Ids4Entity.Client>(clientId);

                return _mapper.Map<Client>(client);
            }
        }
    }
}
