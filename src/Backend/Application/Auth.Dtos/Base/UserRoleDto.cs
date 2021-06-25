using System;
namespace Auth.Dtos.Base
{
    /// <summary>
    /// 用户和角色关系Dto
    /// </summary>
    public class UserRoleDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid? ID { get; set; }

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
