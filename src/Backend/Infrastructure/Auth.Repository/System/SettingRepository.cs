using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entity.SystemEntity;
using Auth.IRepository;
using Auth.IRepository.ISetting;

namespace Auth.Repository.System
{
    public class SettingRepository : RepositoryBase, ISettingRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
