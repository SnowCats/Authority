using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// ApiResourceProperty
    /// </summary>
    [Table("api_resource_properties")]
    public class ApiResourceProperty
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

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
        public int ApiResourceId { get; set; }
    }
}
