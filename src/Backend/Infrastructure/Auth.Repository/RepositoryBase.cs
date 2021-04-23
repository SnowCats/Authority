using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Auth.IRepository;
using Dapper;
using Dapper.Contrib.Plus;

namespace Auth.Repository
{
    /// <summary>
    /// 仓储类
    /// </summary>
    public class RepositoryBase : IRepositoryBase
    {
        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public RepositoryBase()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_unitOfWork">工作单元</param>
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Delete<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            var result = UnitOfWork.WriteConnection.Delete(t, transaction);

            return result;
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            var result = await UnitOfWork.WriteConnection.DeleteAsync(t, transaction);

            return result;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public long Insert<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            var result = UnitOfWork.WriteConnection.Insert(t, transaction);

            return result;
        }

        /// <summary>
        /// 新增（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<long> InsertAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            var result = await UnitOfWork.WriteConnection.InsertAsync(t, transaction);

            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Update<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            bool result = UnitOfWork.WriteConnection.Update(t, transaction);

            return result;
        }

        /// <summary>
        /// 更新（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            var result = await UnitOfWork.WriteConnection.UpdateAsync(t, transaction);

            return result;
        }

        /// <summary>
        /// 某字段的值是否存在重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> HasValueAsync<T>(string field, string value, IDbTransaction transaction = null) where T : class, new()
        {
            var list = await UnitOfWork.ReadConnection.GetListAsync<T>($"WHERE {field}=@Value", new { Value = value }, new List<string> { field }, transaction);

            return list != null && list.Any();
        }

        /// <summary>
        /// GetPagedList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="page">页码</param>
        /// <param name="itemsPerPage">页数</param>
        /// <param name="fields">字段</param>
        /// <param name="conditions">条件</param>
        /// <param name="parameters">参数</param>
        /// <param name="defaultField">默认分页字段</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetPagedListAsync<T>(IDbConnection connection, int page, int itemsPerPage, List<string> fields = null,
            string conditions = "", object parameters = null, string defaultField = "timestamp", string orderBy = "timestamp desc", IDbTransaction transaction = null, int? commandTimeout = null)
            where T : class, new()
        {
            try
            {
                string name = (typeof(T).GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic)?.Name;
                string field = fields == null ? "*" : string.Join(",", fields);

                // mysql数据库
                long timestamp = (long)connection.ExecuteScalar($"select ifnull(min({defaultField}), unix_timestamp()) from {name} where 1=1 {conditions} limit {(page - 1) * itemsPerPage}, 1",
                    parameters, transaction, commandTimeout);
                var list = await connection.QueryAsync<T>($"select {field} from {name} where 1=1 {conditions} and {defaultField} <= {timestamp} limit {(page - 1) * itemsPerPage}, {itemsPerPage}",
                    parameters, transaction, commandTimeout: commandTimeout);

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
