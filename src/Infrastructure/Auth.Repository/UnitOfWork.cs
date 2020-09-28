using System;
using System.Data;
using Auth.IRepository;
using Auth.IRepository.IBase;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Auth.Repository
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 主键
        /// </summary>
        Guid id = Guid.Empty;

        /// <summary>
        /// DbConnection
        /// </summary>
        IDbConnection dbConnection = null;

        /// <summary>
        /// DbTransaction
        /// </summary>
        IDbTransaction dbTransaction = null;

        /// <summary>
        /// 基础数据
        /// </summary>
        public IUserRepository _userRepository { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitOfWork(
            IConfiguration configuration,
            IUserRepository userRepository)
        {
            // 初始化数据库连接
            if(configuration.GetConnectionString("DefaultDB") == DbType.MySql.ToString())   // MySql
            {
                dbConnection = new MySqlConnection(configuration.GetConnectionString("MySqlConnectionString"));
            }
            else if (configuration.GetConnectionString("DefaultDB") == DbType.SqlServer.ToString())    // SqlServer
            {
                dbConnection = new MySqlConnection(configuration.GetConnectionString("SqlServerConnectionString"));
            }
            else    // Other
            {

            }

            // 主键
            id = Guid.NewGuid();
        }

        /// <summary>
        /// 主键
        /// </summary>
        Guid IUnitOfWork.Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        IDbConnection IUnitOfWork.DbConnection { get => dbConnection; }

        /// <summary>
        /// 事务连接对象
        /// </summary>
        IDbTransaction IUnitOfWork.DbTransaction { get => dbTransaction; }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void Begin()
        {
            dbTransaction = dbConnection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            dbTransaction.Commit();
            Dispose();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            dbTransaction.Rollback();
            Dispose();
        }

        /// <summary>
        /// 释放事务
        /// </summary>
        public void Dispose()
        {
            if(dbTransaction != null)
            {
                dbTransaction.Dispose();
            }

            dbTransaction = null;
        }
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbType
    {
        MySql = 0,
        SqlServer = 1
    }
}
