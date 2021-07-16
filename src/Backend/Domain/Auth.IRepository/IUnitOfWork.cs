using System;
using System.Data;
using Auth.IRepository.IBase;
using Auth.IRepository.ISetting;

namespace Auth.IRepository
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        ISettingRepository Setting { get; }

        IUserRepository User { get; }
    }
}
