﻿using System;
using IdentityServer4.Stores;

namespace Auth.IRepository.IIds4
{
    public interface IMySqlPersistedGrantStore : IRepositoryBase, IPersistedGrantStore
    {
    }
}
