using System;
using System.Collections.Generic;
using Auth.Entity.Base;
using Auth.IRepository;
using Auth.IRepository.IBase;
using Microsoft.Extensions.Configuration;

namespace Auth.Repository.Base
{
    /// <summary>
    /// /Base/User
    /// </summary>
    public class UserRepository : Repository, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
