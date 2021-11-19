using System;
using System.Collections.Generic;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// identity_resources
    /// </summary>
    [Table("identity_resources")]
    public class IdentityResource : SeedWork.Entity
    {
        /// <summary>
        /// Enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DisplayName
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
        /// ShowInDiscover
        /// </summary>
        public bool ShowInDiscover { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Updated
        /// </summary>
        public string Updated { get; set; }

        /// <summary>
        /// NonEditable
        /// </summary>
        public bool NonEditable { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Identity资源Claims
        /// </summary>
        [Computed]
        public IList<IdentityResourceClaim> Claims { get; set; }

        /// <summary>
        /// Identity资源Properties
        /// </summary>
        [Computed]
        public IList<IdentityResourceProperty> Properties { get; set; }
    }
}
