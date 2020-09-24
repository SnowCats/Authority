using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Auth.Repository.AppSettings
{
    public sealed class ConnectionStrings
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static readonly Lazy<ConnectionStrings> lazy = new Lazy<ConnectionStrings>(() => new ConnectionStrings());

        /// <summary>
        /// MySql Connection String
        /// </summary>
        public string MySqlConnectionString { get; set; }

        /// <summary>
        /// Mongodb Connection String
        /// </summary>
        public string MongodbConnectionString { get; set; }

        /// <summary>
        /// Redis Connection String
        /// </summary>
        public string RedisConnectionString { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public static ConnectionStrings Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// Get IDbConnection
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetDbConnectionInstance()
        {
            return new MySqlConnection(Instance.MySqlConnectionString);
        }
    }
}
