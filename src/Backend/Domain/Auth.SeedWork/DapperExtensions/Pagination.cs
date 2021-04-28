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
        public int ItemsPerPage { get; set; }
    }
}
