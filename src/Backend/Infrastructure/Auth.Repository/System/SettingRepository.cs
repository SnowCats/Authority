using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entity.System;
using Auth.IRepository;
using Auth.IRepository.ISetting;
using Auth.SeedWork.DapperExtensions;
using Dapper.Contrib.Plus;

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

        /// <summary>
        /// 数据字典分页列表
        /// </summary>
        /// <param name="pagination">分页类</param>
        /// <param name="Wheres"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Setting>> GetPagedList(Pagination pagination, List<string> Wheres, object parameters)
        {
            using (UnitOfWork.Connection)
            {
                List<Table> tables = new List<Table>();

                tables.Add(new Table
                {
                     Name = $"sys_settings",
                     Alias = "st",
                     Fields = new List<string> {
                         nameof(Setting.ID),
                         nameof(Setting.ParentValue),
                         nameof(Setting.Value),
                         nameof(Setting.Text),
                         nameof(Setting.Status),
                         nameof(Setting.Notes),
                         nameof(Setting.CreatedOn),
                         nameof(Setting.CreatedBy)
                     },
                     Wheres = Wheres
                });

                //var list = await UnitOfWork.Connection.GetListAsync<Setting>(tables, pagination, parameters);

                return new List<Setting>();
            }
        }
    }
}
