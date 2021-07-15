using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
        /// 查询单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Guid id, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                return await UnitOfWork.ReadConnection.GetAsync<T>(id);
            }
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public T Get<T>(Guid id, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                return UnitOfWork.ReadConnection.Get<T>(id);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Delete<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                var result = UnitOfWork.WriteConnection.Delete(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                var result = await UnitOfWork.WriteConnection.DeleteAsync(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public long Insert<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                var result = UnitOfWork.WriteConnection.Insert(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 新增（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<long> InsertAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                var result = await UnitOfWork.WriteConnection.InsertAsync(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Update<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                bool result = UnitOfWork.WriteConnection.Update(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 更新（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(T t, IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.WriteConnection)
            {
                var result = await UnitOfWork.WriteConnection.UpdateAsync(t, transaction);

                return result;
            }
        }

        /// <summary>
        /// 某字段的值是否存在重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expression"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> HasValueAsync<T>(string key, string value, Expression<Func<T, dynamic>> expression = null, IDbTransaction transaction = null) where T : class, new()
        {
            // 查询条件
            IList<Condition> conditions = new List<Condition>
            {
                new Condition { Name = key, Value = value, Type = ConditionalType.Equal }
            };

            using (UnitOfWork.ReadConnection)
            {
                var list = await UnitOfWork.ReadConnection.GetListAsync(conditions, expression, transaction);

                return list != null && list.Any();
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TModel">查询类</typeparam>
        /// <typeparam name="TResult">返回实体</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetListAsync<TEntity, TModel>(
            TModel model,
            Expression<Func<TEntity, dynamic>> expression = null,
            IDbTransaction transaction = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                var list = await UnitOfWork.ReadConnection.GetListAsync(model, expression, transaction);

                return list;
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="fields"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(
            IList<Condition> conditions,
            Expression<Func<T, dynamic>> expression = null,
            IDbTransaction transaction = null) where T : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                var list = await UnitOfWork.ReadConnection.GetListAsync(conditions, expression, transaction);

                return list;
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TModel">查询条件</typeparam>
        /// <param name="page">页数</param>
        /// <param name="itemsPerPage">条数</param>
        /// <param name="model">查询条件</param>
        /// <param name="expression">返回的列名</param>
        /// <param name="defaultField">辅助分页列</param>
        /// <param name="orderBy">排序</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetPagedListAsync<TEntity, TModel>(int page, int itemsPerPage,
            TModel model,
            Expression<Func<TEntity, dynamic>> expression = null,
            string defaultField = "timestamp",
            string orderBy = "timestamp desc",
            IDbTransaction transaction = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                var list = await UnitOfWork.ReadConnection.GetPagedListAsync(page, itemsPerPage, model, expression, defaultField, orderBy, transaction);

                return list;
            }
        }

        /// <summary>
        /// 总数
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TModel">查询类</typeparam>
        /// <param name="model">查询实例</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public async Task<long> CountAsync<TEntity, TModel>(TModel model, IDbTransaction transaction = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            using (UnitOfWork.ReadConnection)
            {
                long count = await UnitOfWork.ReadConnection.CountAsync<TEntity, TModel>(model, transaction);

                return count;
            }
        }
    }
}
