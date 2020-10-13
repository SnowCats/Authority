using System;
using Dapper.Contrib.Extensions;

namespace Auth.Entity.Base
{
    /// <summary>
    /// 用户和角色关系表
    /// </summary>
    [Table("base_user_roles")]
    public class UserRole : SeedWork.Entity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid? RoleID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? UserID { get; set; }
    }
}
