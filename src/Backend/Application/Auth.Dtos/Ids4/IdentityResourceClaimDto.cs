using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityResourceClaimDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// IdentityResource
        /// </summary>
        public int IdentityResourceId { get; set; }
    }
}
