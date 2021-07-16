using System;
using System.Collections.Generic;
using Auth.Entity.BaseEntity;
using Auth.IRepository;
using Auth.IRepository.IBase;
using Microsoft.Extensions.Configuration;

namespace Auth.Repository.Base
{
    /// <summary>
    /// /Base/User
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
