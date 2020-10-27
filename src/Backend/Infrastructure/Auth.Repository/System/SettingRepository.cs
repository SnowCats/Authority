using System;
using Auth.IRepository;
using Auth.IRepository.ISetting;
using Auth.Repository.DapperExtension;

namespace Auth.Repository.System
{
    public class SettingRepository : Repository, ISettingRepository
    {
        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public dynamic GetPagedList()
        {
            using (UnitOfWork.Connection)
            {
                UnitOfWork.Begin();

                var result = UnitOfWork.Connection.GetPagedList<dynamic>("", 10, 1, transaction: UnitOfWork.Transaction);

                UnitOfWork.Commit();

                return result;
            }
        }
    }
}
