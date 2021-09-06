using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("identity_resource_properties")]
    public class IdentityResourceProperty
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// IdentityResource
        /// </summary>
        public int IdentityResourceId { get; set; }
    }
}
