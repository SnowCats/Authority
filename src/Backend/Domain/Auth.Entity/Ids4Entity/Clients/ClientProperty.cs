using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("client_properties")]
    public class ClientProperty : SeedWork.Entity
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
