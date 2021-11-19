using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiResourceSecret
    /// </summary>
    [Table("api_resource_secrets")]
    public class ApiResourceSecret : SeedWork.Entity
    {
        /// <summary>
        /// 描述
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
        /// 
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// ApiResourceId
        /// </summary>
        public Guid ApiResourceId { get; set; }
    }
}
