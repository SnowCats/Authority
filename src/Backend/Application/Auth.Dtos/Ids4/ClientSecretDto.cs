using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// client_secrets
    /// </summary>
    public class ClientSecretDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Expiration
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
