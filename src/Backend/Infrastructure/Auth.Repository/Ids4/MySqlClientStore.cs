using System;
using System.Threading.Tasks;
using Auth.IRepository;
using Auth.IRepository.IIds4;
using Auth.Utility;
using IdentityServer4.Models;

namespace Auth.Repository.Ids4
{
    /// <summary>
    /// MySqlClientStore
    /// </summary>
    public class MySqlClientStore : RepositoryBase, IMySqlClientStore
    {
        private readonly IDbContext _dbContext;

        public MySqlClientStore(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            using (_dbContext.InitConnection(RW.R))
            {

            }

            return null;
        }
    }
}
