using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiResourceScope
    /// </summary>
    [Table("api_resource_scopes")]
    public class ApiResourceScope : SeedWork.Entity
    {
        /// <summary>
        /// 作用域
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// ApiResourceId
        /// </summary>
        public Guid ApiResourceId { get; set; }
    }
}
