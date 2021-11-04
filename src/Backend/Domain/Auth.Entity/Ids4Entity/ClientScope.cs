using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// client_scopes
    /// </summary>
    [Table("client_scopes")]
    public class ClientScope
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 允许的CORS来源Uri
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 客户端Id
        /// </summary>
        public int ClientId { get; set; }
    }
}
