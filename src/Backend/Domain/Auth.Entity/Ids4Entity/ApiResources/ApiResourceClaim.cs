using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiResourceClaim
    /// </summary>
    [Table("api_resource_claims")]
    public class ApiResourceClaim : SeedWork.Entity
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ApiResourceId
        /// </summary>
        public Guid ApiResourceId { get; set; }
    }
}
