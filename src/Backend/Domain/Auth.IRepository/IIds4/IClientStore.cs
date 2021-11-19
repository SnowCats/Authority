using System;
using IdentityServer4.Stores;

namespace Auth.IRepository.IIds4
{
    /// <summary>
    /// Client Store
    /// </summary>
    public interface IClientStore : IRepositoryBase, IdentityServer4.Stores.IClientStore
    {

    }
}
