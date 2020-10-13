using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Auth.Repository.DapperExtension
{
    /// <summary>
    /// Dapper Contrib Extension
    /// </summary>
    public static partial class SqlMapperExtensions
    {
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection">数据库连接对象</param>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="transaction">事务对象</param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetPagedList<T>(this IDbConnection connection, string sql, object parameters, int pageIndex, int pageSize, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class, new()
        {
            return connection.GetAll<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetListByWhere<T>(this IDbConnection connection, string where, object parameters, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class, new()
        {
            string tableName = GetAttributeTableName<T>();
            string sql = $"SELECT * FROM {tableName} {where}";

            return connection.Query<T>(sql, parameters, transaction: transaction, buffered: true, commandTimeout: commandTimeout, commandType: commandType);
        }

        #region 公共方法

        /// <summary>
        /// Get Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetAttributeTableName<T>()
        {
            TableAttribute attribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0];

            if(attribute != null)
            {
                return attribute.Name;
            }
            else
            {
                return typeof(T).Name;
            }
        }

        #endregion
    }
}
