using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ApiResource
    /// </summary>
    public class ApiResourceDto
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
        /// DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// AllowedAccessT
        /// </summary>
        public string AllowedAccessT { get; set; }

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
        /// LastAccessed
        /// </summary>
        public string LastAccessed { get; set; }

        /// <summary>
        /// NonEditable
        /// </summary>
        public bool NonEditable { get; set; }

        /// <summary>
        /// ApiResourceClaim
        /// </summary>
        public ApiResourceClaimDto ApiResourceClaim { get; set; }

        /// <summary>
        /// ApiResourceProperty
        /// </summary>
        public ApiResourcePropertyDto ApiResourceProperty { get; set; }

        /// <summary>
        /// ApiResourceScope
        /// </summary>
        public ApiResourceScopeDto ApiResourceScope { get; set; }

        /// <summary>
        /// ApiResourceSecret
        /// </summary>
        public ApiResourceSecretDto ApiResourceSecret { get; set; }
    }
}
