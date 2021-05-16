using System;
namespace Auth.Application.Common
{
    public class Pagination
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        public int ItemsPerPage { get; set; }
    }
}
