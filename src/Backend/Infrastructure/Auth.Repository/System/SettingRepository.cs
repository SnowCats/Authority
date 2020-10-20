using System;
using Auth.IRepository;
using Auth.IRepository.ISetting;

namespace Auth.Repository.System
{
    public class SettingRepository : Repository, ISettingRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
