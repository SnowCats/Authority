using System;
namespace Auth.SeedWork.Attributes
{
    /// <summary>
    /// 此特性用来标记更新时需要忽略的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : Attribute
    {

    }
}
