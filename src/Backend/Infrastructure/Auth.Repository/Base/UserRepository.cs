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
        /// IRepository
        /// </summary>
        private IRepository.IRepository Repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository.IRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Repository = repository;
        }
    }
}
