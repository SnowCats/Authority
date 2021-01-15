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
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 配置对象
        /// </summary>
        private IConfiguration Configuration;

        /// <summary>
        /// 数据库连接对象(写)
        /// </summary>
        public static IDbConnection connection;

        /// <summary>
        /// 数据库连接对象(读)
        /// </summary>
        public static IDbConnection dbConnection;

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        public static IDbTransaction transaction;

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitOfWork(IConfiguration configuration)
        {
            // 配置对象
            Configuration = configuration;

            // 初始化数据库连接
            if (int.TryParse(Configuration.GetConnectionString("DefaultDB"), out int dbType))
            {
                if (dbType == (int)DbType.MySql)
                {
                    connection = new MySqlConnection(Configuration.GetConnectionString("MySqlConnectionString:Write"));
                    dbConnection = new MySqlConnection(Configuration.GetConnectionString("MySqlConnectionString:Read"));
                }
                else if (dbType == (int)DbType.SqlServer)
                {
                    connection = new SqlConnection(Configuration.GetConnectionString("SqlServerConnectionString:Write"));
                    dbConnection = new SqlConnection(Configuration.GetConnectionString("SqlServerConnectionString:Read"));
                }
            }
            else
            {
                throw new Exception("\"DefaultDB\" is incorrect, Please check your appsettings.{*}.json. example: \"DefaultDB\": 0");
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        Guid IUnitOfWork.Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        /// <summary>
        /// IUnitOfWork数据库连接对象(写)
        /// </summary>
        IDbConnection IUnitOfWork.Connection
        {
            get
            {
                return connection;
            }
        }

        /// <summary>
        /// IUnitOfWork数据库连接对象(读)
        /// </summary>
        IDbConnection IUnitOfWork.DbConnection
        {
            get
            {
                return dbConnection;
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
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            transaction = connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                Dispose();
            }
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
        MySql,
        SqlServer
    }
}
