using System;
using Dapper.Contrib.Extensions;

namespace Auth.Entity.System
{
    /// <summary>
    /// 模块名
    /// </summary>
    [Table("sys_modules")]
    public class Module : SeedWork.Entity
    {
        /// <summary>
        /// 上级节点
        /// </summary>
        public Guid? ParentID { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模块图标名
        /// </summary>
        public string Icon { get; set; }

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
