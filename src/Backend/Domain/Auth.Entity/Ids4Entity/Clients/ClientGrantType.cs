using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ClientGrantTypes
    /// </summary>
    [Table("client_grant_types")]
    public class ClientGrantType : SeedWork.Entity
    {
        /// <summary>
        /// GrantType
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
