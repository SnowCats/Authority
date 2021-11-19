using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// client_scopes
    /// </summary>
    [Table("client_scopes")]
    public class ClientScope : SeedWork.Entity
    {
        /// <summary>
        /// 允许的CORS来源Uri
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 客户端Id
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
