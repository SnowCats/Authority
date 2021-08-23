using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ApiResourceScope
    /// </summary>
    public class ApiResourceScopeDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 作用域
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// ApiResourceId
        /// </summary>
        public int ApiResourceId { get; set; }
    }
}
