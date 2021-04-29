using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
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
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expression"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<bool> HasValueAsync<T>(string key, string value, Expression<Func<T, dynamic>> expression = null, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TModel">查询类</typeparam>
        /// <typeparam name="TResult">返回实体</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListAsync<TEntity, TModel>(
            TModel model,
            Expression<Func<TEntity, dynamic>> expression = null,
            IDbTransaction transaction = null)
            where TEntity : class, new()
            where TModel : class, new();

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="fields"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync<T>(
            IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs,
            Expression<Func<T, dynamic>> expression = null,
            IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="keyValuePairs"></param>
        /// <param name="expression"></param>
        /// <param name="defaultField"></param>
        /// <param name="orderBy"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetPagedListAsync<T>(int page, int itemsPerPage,
            IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs,
            Expression<Func<T, dynamic>> expression = null,
            string defaultField = "timestamp",
            string orderBy = "timestamp desc",
            IDbTransaction transaction = null)
            where T : class, new();

        /// <summary>
        /// 总条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValuePairs"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<long> Count<T>(IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs, IDbTransaction transaction = null)
            where T : class, new();
    }
}
