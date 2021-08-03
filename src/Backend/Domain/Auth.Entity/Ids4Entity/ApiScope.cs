using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiScope
    /// </summary>
    [Table("api_scopes")]
    public class ApiScope
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Emphasize
        /// </summary>
        public bool Emphasize { get; set; }

        /// <summary>
        /// ShowInDiscoveryDocument
        /// </summary>
        public object ShowInDiscoveryDocument { get; set; }

        /// <summary>
        /// ApiScopeClaim
        /// </summary>
        [Computed]
        public ApiScopeClaim ApiScopeClaim { get; set; }

        /// <summary>
        /// ApiScopeProperty
        /// </summary>
        [Computed]
        public ApiScopeProperty ApiScopeProperty { get; set; }
    }
}
