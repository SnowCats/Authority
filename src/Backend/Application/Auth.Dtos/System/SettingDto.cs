﻿using System;
using Auth.Utility;

namespace Auth.Dtos.System
{
    /// <summary>
    /// 字典Dto
    /// </summary>
    public class SettingDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid? ID { get; set; }

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

        #region 值对象

        /// <summary>
        /// 上级节点值
        /// </summary>
        public string SuperiorValue { get; set; }

        /// <summary>
        /// 上级节点文本
        /// </summary>
        public string SuperiorText { get; set; }

        #endregion
    }
}
