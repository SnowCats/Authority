using System;
using System.Collections.Generic;

namespace Auth.Application.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagination<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        public IEnumerable<T> List { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public long Count { get; set; }
    }
}
