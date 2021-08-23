using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ClientGrantTypes
    /// </summary>
    public class ClientGrantTypeDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// GrantType
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
