using System;
using System.Threading.Tasks;

namespace Auth.IRepository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 新增接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Guid Insert<T>(T t) where T : SeedWork.Entity;

        /// <summary>
        /// 新增接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<Guid> InsertAsync<T>(T t) where T : SeedWork.Entity;

        /// <summary>
        /// 更新接口
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        bool Update<T>(T t) where T : class, new();

        /// <summary>
        /// 更新接口
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<bool> UpdateAsync<T>(T t) where T : class, new();

        /// <summary>
        /// 删除接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        bool Delete<T>(T t) where T : class, new();

        /// <summary>
        /// 删除接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="t">实体实例</param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(T t) where T : class, new();
    }
}
