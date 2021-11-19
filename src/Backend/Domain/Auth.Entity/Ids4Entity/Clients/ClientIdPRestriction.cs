using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("clientId_p_restrictions")]
    public class ClientIdPRestriction : SeedWork.Entity
    {
        /// <summary>
        /// Provider
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
