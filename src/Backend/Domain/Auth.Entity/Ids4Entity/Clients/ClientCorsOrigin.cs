using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ClientCorsOrgins
    /// </summary>
    [Table("client_cors_origins")]
    public class ClientCorsOrigin : SeedWork.Entity
    {
        /// <summary>
        /// Origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
