using System;
using System.Data;
using Auth.IRepository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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
        /// 配置对象
        /// </summary>
        private IConfiguration Configuration;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        IDbConnection connection = null;

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        IDbTransaction transaction = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitOfWork(IConfiguration configuration)
        {
            // 配置对象
            Configuration = configuration;
            // 主键
            id = Guid.NewGuid();

            // 初始化数据库连接
            if (Configuration.GetConnectionString("DefaultDB") == DbType.MySql.ToString())   // MySql
            {
                connection = new MySqlConnection(Configuration.GetConnectionString("MySqlConnectionString:Write"));
            }
            else if (Configuration.GetConnectionString("DefaultDB") == DbType.SqlServer.ToString())    // SqlServer
            {
                connection = new SqlConnection(Configuration.GetConnectionString("SqlServerConnectionString"));
            }
            else    // Other DataBase
            {
                connection = new MySqlConnection(Configuration.GetConnectionString("MySqlConnectionString"));
            }
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
        /// IUnitOfWork数据库连接对象
        /// </summary>
        IDbConnection IUnitOfWork.Connection {
            get
            {
                return connection;
            }
        }

        /// <summary>
        /// IUnitOfWork数据库事务对象
        /// </summary>
        IDbTransaction IUnitOfWork.Transaction
        {
            get
            {
                return transaction;
            }
        }

        #region 事务处理

        /// <summary>
        /// 开始事务
        /// </summary>
        public void Begin()
        {
            transaction = connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            transaction.Commit();
            Dispose();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            transaction.Rollback();
            Dispose();
        }

        /// <summary>
        /// 释放事务
        /// </summary>
        public void Dispose()
        {
            if(transaction != null)
            {
                transaction.Dispose();
            }

            transaction = null;
        }

        #endregion
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
