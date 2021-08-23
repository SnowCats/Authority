using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiScopeClaimDto
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
        /// ScopeId
        /// </summary>
        public int ScopeId { get; set; }
    }
}
