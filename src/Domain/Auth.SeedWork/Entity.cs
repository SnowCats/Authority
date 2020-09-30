using System;
using Dapper.Contrib.Extensions;

namespace Auth.SeedWork
{
    /// <summary>
    /// 抽象实体基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ExplicitKey]
        public Guid ID { get; set; }
    }
}
