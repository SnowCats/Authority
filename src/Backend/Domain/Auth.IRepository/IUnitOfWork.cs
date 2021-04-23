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
        /// 数据库连接对象(读)
        /// </summary>
        public IDbConnection ReadConnection { get; }

        /// <summary>
        /// 数据库连接对象(写)
        /// </summary>
        public IDbConnection WriteConnection { get; }

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        public IDbTransaction Transaction { get; }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void Begin();

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Complete();

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback();
    }
}
