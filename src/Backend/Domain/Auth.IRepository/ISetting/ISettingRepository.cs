using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entity.System;
using Auth.SeedWork.DapperExtensions;

namespace Auth.IRepository.ISetting
{
    /// <summary>
    /// 数据字典仓储接口
    /// </summary>
    public interface ISettingRepository : IRepositoryBase
    {
        /// <summary>
        /// 数据字典分页列表
        /// </summary>
        /// <param name="pagination">分页类</param>
        /// <param name="Wheres"></param>
        /// <returns></returns>
        Task<IEnumerable<Setting>> GetPagedList(int page, int itemsPerPage, IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs);
    }
}
