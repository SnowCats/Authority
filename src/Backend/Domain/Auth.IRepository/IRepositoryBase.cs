using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Auth.IRepository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// 新增接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        long Insert<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 新增接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<long> InsertAsync<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 更新接口
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        bool Update<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 更新接口
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 删除接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        bool Delete<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 删除接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(T t, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 某字段的值是否存在重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HasValueAsync<T>(string field, string value, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="fields"></param>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="defaultField"></param>
        /// <param name="orderBy"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetPagedListAsync<T>(IDbConnection connection, int page, int itemsPerPage, List<string> fields = null,
            string conditions = "", object parameters = null, string defaultField = "timestamp", string orderBy = "timestamp desc", IDbTransaction transaction = null,
            int? commandTimeout = null)
            where T : class, new();
    }
}
