﻿using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.SystemEntity
{
    /// <summary>
    /// 接口表
    /// </summary>
    [Table("sys_apis")]
    public class Api : SeedWork.Entity
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid? ModuleID { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string Route { get; set; }

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
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [IgnoreUpdate]
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
