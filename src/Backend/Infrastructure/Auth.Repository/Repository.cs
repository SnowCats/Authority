using System;
using System.Data;
using System.Threading.Tasks;
using Auth.IRepository;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;

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
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Repository()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_unitOfWork">工作单元</param>
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public bool Delete<T>(T t) where T : class, new()
        {
            using(UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                var result = UnitOfWork.Connection.Delete(t, UnitOfWork.Transaction);

                UnitOfWork.Commit();

                return result;
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
            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                var result = await UnitOfWork.Connection.DeleteAsync(t, UnitOfWork.Transaction);

                UnitOfWork.Commit();

                return result;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public Guid Insert<T>(T t) where T : SeedWork.Entity
        {
            t.ID = UnitOfWork.Id;

            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                UnitOfWork.Connection.Insert(t, UnitOfWork.Transaction);

                UnitOfWork.Commit();

                return t.ID;
            }
        }

        /// <summary>
        /// 新增（异步）
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        public async Task<Guid> InsertAsync<T>(T t) where T : SeedWork.Entity
        {
            t.ID = UnitOfWork.Id;

            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                await UnitOfWork.Connection.InsertAsync(t);

                UnitOfWork.Commit();

                return t.ID;
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
            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                var result = UnitOfWork.Connection.Update(t);

                UnitOfWork.Commit();

                return result;
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
            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                var result = await UnitOfWork.Connection.UpdateAsync(t);

                UnitOfWork.Commit();

                return result;
            }
        }
    }
}
