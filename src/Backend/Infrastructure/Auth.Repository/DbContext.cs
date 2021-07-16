using System;
using System.Data;
using System.Data.SqlClient;
using Auth.IRepository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Auth.Utility;

namespace Auth.Repository
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbContext : IDbContext
    {
        /// <summary>
        /// 配置文件访问对象
        /// </summary>
        private IConfiguration Configuration;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private IDbConnection Connection = null;

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        private IDbTransaction Transaction = null;

        /// <summary>
        /// Property
        /// </summary>
        IDbConnection IDbContext.Connection => Connection;

        /// <summary>
        /// Property
        /// </summary>
        IDbTransaction IDbContext.Transaction => Transaction;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbContext(IConfiguration configuration)
        {
            // 配置对象
            Configuration = configuration;
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        /// <returns></returns>
        public IDbConnection InitConnection(RW rw)
        {
            // 配置的数据库类型
            string database = Configuration.GetConnectionString("Database");

            // 默认数据库不为空
            if (!string.IsNullOrWhiteSpace(database))
            {
                // MySQL
                if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.MySQL)?.ToUpper())
                {
                    // 读库
                    if (rw == RW.R)
                    {
                        Connection = new MySqlConnection(Configuration.GetConnectionString("MySQL:R"));
                    }
                    // 写库
                    else if (rw == RW.W)
                    {
                        Connection = new MySqlConnection(Configuration.GetConnectionString("MySQL:W"));
                    }

                    return Connection;
                }
                // SQLServer
                else if (database.ToUpper() == Enum.GetName(typeof(DATABASE), DATABASE.SQLServer)?.ToUpper())
                {
                    // 读库
                    if (rw == RW.R)
                    {
                        Connection = new SqlConnection(Configuration.GetConnectionString("SQLServer:R"));
                    }
                    // 写库
                    else if (rw == RW.W)
                    {
                        Connection = new SqlConnection(Configuration.GetConnectionString("SQLServer:W"));
                    }

                    return Connection;
                }

                return Connection;
            }
            else
            {
                throw new Exception("\"DefaultDB\" is incorrect, Please check your appsettings.{*}.json. example: \"Database\": \"MySQL\"");
            }
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Complete()
        {
            try
            {
                Transaction?.Commit();
            }
            catch
            {
                Transaction?.Rollback();
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}
