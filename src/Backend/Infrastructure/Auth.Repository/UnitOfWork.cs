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
        public static IDbConnection writeConnection;

        /// <summary>
        /// 数据库连接对象(读)
        /// </summary>
        public static IDbConnection readConnection;

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
            string database = Configuration.GetConnectionString("Database");

            if (!string.IsNullOrWhiteSpace(database))
            {
                if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.MySQL)?.ToUpper())
                {
                    writeConnection = new MySqlConnection(Configuration.GetConnectionString("MySQL:W"));
                    readConnection = new MySqlConnection(Configuration.GetConnectionString("MySQL:R"));
                }
                if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.SQLServer)?.ToUpper())
                {
                    writeConnection = new SqlConnection(Configuration.GetConnectionString("SQLServer:W"));
                    readConnection = new SqlConnection(Configuration.GetConnectionString("SQLServer:R"));
                }
            }
            else
            {
                throw new Exception("\"DefaultDB\" is incorrect, Please check your appsettings.{*}.json. example: \"Database\": \"MySQL\"");
            }
        }

        /// <summary>
        /// IUnitOfWork数据库连接对象(写)
        /// </summary>
        IDbConnection IUnitOfWork.WriteConnection
        {
            get
            {
                string database = Configuration.GetConnectionString("Database");

                if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.MySQL)?.ToUpper())
                {
                    writeConnection = new MySqlConnection(Configuration.GetConnectionString("MySQL:W"));
                }
                if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.SQLServer)?.ToUpper())
                {
                    writeConnection = new SqlConnection(Configuration.GetConnectionString("SQLServer:W"));
                }

                return writeConnection;
            }
        }

        /// <summary>
        /// IUnitOfWork数据库连接对象(读)
        /// </summary>
        IDbConnection IUnitOfWork.ReadConnection
        {
            get
            {
                string database = Configuration.GetConnectionString("Database");

                // 初始化数据库连接
                if (database == Enum.GetName(typeof(DATABASE), DATABASE.MySQL)?.ToUpper())
                {
                    readConnection = new MySqlConnection(Configuration.GetConnectionString("MySQL:R"));
                }
                else if (database == Enum.GetName(typeof(DATABASE), DATABASE.SQLServer))
                {
                    readConnection = new SqlConnection(Configuration.GetConnectionString("SQLServer:R"));
                }

                return readConnection;
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
            if(writeConnection.State == ConnectionState.Closed)
            {
                writeConnection.Open();
            }

            transaction = writeConnection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Complete()
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
            transaction?.Dispose();
            readConnection.Dispose();
            writeConnection.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DATABASE
    {
        MySQL,
        SQLServer
    }
}
