using System;
using System.Data;
using Auth.Utility;

namespace Auth.IRepository
{
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <returns></returns>
        IDbConnection InitConnection(RW rw);

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        IDbTransaction Transaction { get; }

        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        void Complete();
    }
}
