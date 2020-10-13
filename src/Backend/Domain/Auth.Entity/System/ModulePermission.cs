using System;
using Dapper.Contrib.Extensions;

namespace Auth.Entity.System
{
    /// <summary>
    /// 模块关系表
    /// </summary>
    [Table("sys_module_permissions")]
    public class ModulePermission : SeedWork.Entity
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid? ModuleID { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid? PermissionID { get; set; }

        /// <summary>
        /// 状态，0:启用，1:禁用
        /// </summary>
        public short? Status { get; set; }

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
    }
}
