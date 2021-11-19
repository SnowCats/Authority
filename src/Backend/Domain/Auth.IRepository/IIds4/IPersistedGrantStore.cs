using System;

namespace Auth.IRepository.IIds4
{
    /// <summary>
    /// IPersistedGrantStore
    /// </summary>
    public interface IPersistedGrantStore : IRepositoryBase, IdentityServer4.Stores.IPersistedGrantStore
    {
    }
}
