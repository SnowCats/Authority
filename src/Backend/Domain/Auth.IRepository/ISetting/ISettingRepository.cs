using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entity.System;

namespace Auth.IRepository.ISetting
{
    /// <summary>
    /// 数据字典仓储接口
    /// </summary>
    public interface ISettingRepository : IRepository
    {
        /// <summary>
        /// 数据字典分页列表
        /// </summary>
        /// <param name="pagination">分页类</param>
        /// <param name="Wheres"></param>
        /// <returns></returns>
        async Task<IEnumerable<Setting>> GetPagedList(Pagination pagination, List<string> Wheres);
    }
}
