using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ApiResourceClaim
    /// </summary>
    public class ApiResourceClaimDto
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
        /// ApiResourceId
        /// </summary>
        public int ApiResourceId { get; set; }
    }
}
