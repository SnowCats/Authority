using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiResourceProperty
    /// </summary>
    [Table("api_resource_properties")]
    public class ApiResourceProperty : SeedWork.Entity
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
        /// ApiResourceId
        /// </summary>
        public Guid ApiResourceId { get; set; }
    }
}
