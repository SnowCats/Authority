using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("api_scope_claims")]
    public class ApiScopeClaim : SeedWork.Entity
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ScopeId
        /// </summary>
        public Guid ScopeId { get; set; }
    }
}
