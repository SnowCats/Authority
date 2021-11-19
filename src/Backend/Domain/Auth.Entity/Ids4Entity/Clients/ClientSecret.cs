using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// client_secrets
    /// </summary>
    [Table("client_secrets")]
    public class ClientSecret : SeedWork.Entity
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 到期
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// 类型，SharedSecret，X509Thumbprint
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Created { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 客户端Id
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
