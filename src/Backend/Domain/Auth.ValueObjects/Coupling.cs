using System;
using System.Collections.Generic;
using Auth.SeedWork;

namespace Auth.ValueObjects
{
    /// <summary>
    /// 耦合对象，如上下级，外键对象等
    /// </summary>
    public class Coupling : ValueObject
    {
        public string Value { get; }

        public string Text { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Text;
        }
    }
}
