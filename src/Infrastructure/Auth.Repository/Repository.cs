using System;
using System.Data;
using System.Threading.Tasks;
using Auth.IRepository;
using Dapper.Contrib.Extensions;

namespace Auth.Repository
{
    /// <summary>
    /// 仓储类
    /// </summary>
    public class Repository : IRepository.IRepository
    {
        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_unitOfWork">工作单元</param>
        public Repository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Delete<T>(T t) where T : class, new()
        {
            using(var connection = unitOfWork.Connection)
            {
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection.Delete(t);
            }
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<T>(T t) where T : class, new()
        {
            using (var connection = unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return await connection.DeleteAsync(t);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public dynamic Insert<T>(T t) where T : class, new()
        {
            using (var connection = unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection.Insert(t);
            }
        }

        /// <summary>
        /// 新增（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<dynamic> InsertAsync<T>(T t) where T : class, new()
        {
            using (var connection = unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return await connection.InsertAsync(t);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Update<T>(T t) where T : class, new()
        {
            using (var connection = unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection.Update(t);
            }
        }

        /// <summary>
        /// 更新（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(T t) where T : class, new()
        {
            using (var connection = unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return await connection.UpdateAsync(t);
            }
        }
    }
}
