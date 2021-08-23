using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ClientClaim
    /// </summary>
    public class ClientClaimDto
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
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
