using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.BaseEntity
{
    /// <summary>
    /// 声明类型
    /// </summary>
    [Table("base_claim_types")]
    public class ClaimType : SeedWork.Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [FieldName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 值类型key
        /// </summary>
        [FieldName("value_type")]
        public short? ValueType { get; set; }

        /// <summary>
        /// 值类型value
        /// </summary>
        [FieldName("value_type_as_string")]
        public string ValueTypeAsString { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [FieldName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 是否必要
        /// </summary>
        [FieldName("required")]
        public bool? Required { get; set; }

        /// <summary>
        /// 是否静态
        /// </summary>
        [FieldName("is_static")]
        public bool? IsStatic { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [IgnoreUpdate]
        [FieldName("created")]
        public string Created { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 更新日期
        /// </summary>
        [FieldName("updated")]
        public string Updated { get; set; }
    }
}
