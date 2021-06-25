using System;
using Auth.Utility;

namespace Auth.Dtos.Base
{
    /// <summary>
    /// 组织架构Dto
    /// </summary>
    public class OrganizationDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid? ID { get; set; }

        /// <summary>
        /// 上级组织ID
        /// </summary>
        public Guid? ParentID { get; set; }

        /// <summary>
        /// 上级组织名称
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
        public long Timestamp { get; set; } = DateUtility.UnixTimestampFromTime();

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
