﻿using System;
using Dapper.Contrib.Extensions;

namespace Auth.Entity.System
{
    /// <summary>
    /// 字典
    /// </summary>
    [Table("sys_settings")]
    public class Setting : SeedWork.Entity
    {
        /// <summary>
        /// 上级字典Key
        /// </summary>
        public string ParentKey { get; set; }

        /// <summary>
        /// 字典Key
        /// </summary>
        public string CodeKey { get; set; }

        /// <summary>
        /// 字典Value
        /// </summary>
        public string CodeValue { get; set; }

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
        public long TimeStamp { get; set; }

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