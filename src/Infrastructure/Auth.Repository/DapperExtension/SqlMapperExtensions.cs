using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Auth.Repository.DapperExtension
{
    /// <summary>
    /// Dapper Contrib Extension
    /// </summary>
    public static partial class SqlMapperExtensions
    {
        public static IEnumerable<T> GetPagedList<T>(this IDbConnection connection, string sql, object parameters, int pageIndex, int pageSize, IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            return null;
        }
    }
}
