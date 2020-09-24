using System;
using System.Collections.Generic;
using Auth.Entity.Base;

namespace Auth.IRepository.IBase
{
    public interface IBaseRepository
    {
        IEnumerable<User> GetUsers();
    }
}
