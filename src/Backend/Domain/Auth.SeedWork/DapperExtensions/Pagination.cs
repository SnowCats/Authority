using System;
namespace Auth.SeedWork.DapperExtensions
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 第几页
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
