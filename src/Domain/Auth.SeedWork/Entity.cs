using System;
using Dapper.Contrib.Extensions;

namespace Auth.SeedWork
{
    public class Entity
    {
        [ExplicitKey]
        public Guid ID { get; set; }
    }
}
