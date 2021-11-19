using System;
using IdentityServer4.Stores;

namespace Auth.IRepository.IIds4
{
    /// <summary>
    /// IResourceStore
    /// </summary>
    public interface IResourceStore : IRepositoryBase, IdentityServer4.Stores.IResourceStore
    {
    }
}
