using System;
namespace Auth.Dto.Base
{
    /// <summary>
    /// 角色信息Dto
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid? ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态，0:启用，1:禁用
        /// </summary>
        public short? Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 数据时间戳
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public Guid? ModifiedBy { get; set; }
    }
}
