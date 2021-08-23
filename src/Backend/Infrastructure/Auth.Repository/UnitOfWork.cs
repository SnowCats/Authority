using System;
using System.Data;
using Auth.IRepository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Auth.IRepository.ISetting;
using Auth.IRepository.IBase;

namespace Auth.Repository
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// User Property
        /// </summary>
        private readonly IUserRepository _user;

        /// <summary>
        /// Setting Property
        /// </summary>
        private readonly ISettingRepository _setting;

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="user"></param>
        /// <param name="setting"></param>
        public UnitOfWork(
            IUserRepository user,
            ISettingRepository setting
        )
        {
            _user = user;
            _setting = setting;
        }

        /// <summary>
        /// Setting Repository
        /// </summary>
        public ISettingRepository Setting => _setting;

        /// <summary>
        /// User Repository
        /// </summary>
        public IUserRepository User => _user;
    }
}
