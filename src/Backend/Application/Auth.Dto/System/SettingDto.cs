﻿using System;
namespace Auth.Dto.System
{
    /// <summary>
    /// 字典Dto
    /// </summary>
    public class SettingDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 上级字典Value
        /// </summary>
        public string ParentValue { get; set; }

        /// <summary>
        /// 字典Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 字典Text
        /// </summary>
        public string Text { get; set; }

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
