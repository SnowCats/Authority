using System;
using System.Collections.Generic;

namespace Auth.Application.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedList<T>
    {
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
