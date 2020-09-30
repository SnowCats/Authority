﻿using System;
using System.Collections.Generic;
using Auth.Entity.Base;
using Auth.IRepository.IBase;

namespace Auth.Repository.Base
{
    /// <summary>
    /// /Base/User
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// IRepository
        /// </summary>
        private IRepository.IRepository Repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository.IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    ID = Guid.NewGuid(),
                    UserName = "锦羽",
                    Password = "123456",
                    Gender = "女",
                    Email = "jinyu@163.com",
                    Phone = "15250123123"
                },
                new User
                {
                    ID = Guid.NewGuid(),
                    UserName = "锦妍",
                    Password = "123456",
                    Gender = "女",
                    Email = "jinyan@163.com",
                    Phone = "15250123123"
                },
                new User
                {
                    ID = Guid.NewGuid(),
                    UserName = "百灵",
                    Password = "123456",
                    Gender = "女",
                    Email = "bailing@163.com",
                    Phone = "15250123123"
                }
            };
        }
    }
}