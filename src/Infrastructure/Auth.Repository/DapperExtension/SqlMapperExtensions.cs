using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
        /// <param name="connection"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetPagedList<T>(this IDbConnection connection, string sql, object parameters, int pageIndex, int pageSize, IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            return connection.GetAll<T>();
        }
    }
}
