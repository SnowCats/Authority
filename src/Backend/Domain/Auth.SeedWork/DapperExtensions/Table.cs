using System;
using System.Collections.Generic;

namespace Auth.SeedWork.DapperExtensions
{
    /// <summary>
    /// Dapper扩展Table类
    /// </summary>
    public class Table
    {
        /// <summary>
        /// 表名或者SQL
        /// </summary>
        public dynamic Name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// -1: Inner, 0: Left, 1: Right;
        /// </summary>
        public int? JoinType { get; set; }

        /// <summary>
        /// 连接，主表为空
        /// </summary>
        public string JoinField { get; set; } = "ID";

        /// <summary>
        /// 查询条件
        /// </summary>
        public List<string> Wheres { get; set; }
    }

    /// <summary>
    /// 数据库表连接类型
    /// </summary>
    public enum JoinType
    {
        Inner = -1,
        Left = 0,
        Right = 1
    }
}
