using System;
using System.Collections.Generic;
using Auth.SeedWork;

namespace Auth.ValueObjects
{
    /// <summary>
    /// 耦合对象，如上下级，外键对象等
    /// </summary>
    public class KeyValue : ValueObject
    {
        public string Value { get; set; }

        public string Text { get; set; }
    }
}
