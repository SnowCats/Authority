using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Auth.Entity.Base
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("base_users")]
    public class User : SeedWork.Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public short? Gender { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>
        public Guid? PositionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 状态，0:启用，1:禁用
        /// </summary>
        public short? Status { get; set; }

        /// <summary>
        /// 数据时间戳
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public Guid? ModifiedBy { get; set; }

        /// <summary>
        /// 用户角色关系列表
        /// </summary>
        [Computed]
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
