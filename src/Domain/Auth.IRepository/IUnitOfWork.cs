using System;
using System.Data;

namespace Auth.IRepository
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 新增记录后返回的主键
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        IDbConnection DbConnection { get; }

        /// <summary>
        /// 数据库事务
        /// </summary>
        IDbTransaction DbTransaction { get; }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void Begin();

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback();
    }
}
