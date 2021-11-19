using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("identity_resource_properties")]
    public class IdentityResourceProperty : SeedWork.Entity
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
