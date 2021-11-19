using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("api_scope_properties")]
    public class ApiScopeProperty : SeedWork.Entity
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ScopeId
        /// </summary>
        public Guid ScopeId { get; set; }
    }
}
