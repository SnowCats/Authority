using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("identity_resource_claims")]
    public class IdentityResourceClaim : SeedWork.Entity
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// IdentityResource
        /// </summary>
        public Guid IdentityResourceId { get; set; }
    }
}
