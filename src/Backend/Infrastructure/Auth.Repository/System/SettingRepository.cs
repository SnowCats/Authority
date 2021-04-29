﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entity.System;
using Auth.IRepository;
using Auth.IRepository.ISetting;

namespace Auth.Repository.System
{
    public class SettingRepository : RepositoryBase, ISettingRepository
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
        public async Task<IEnumerable<Setting>> GetPagedList(int page, int itemsPerPage, IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs)
        {
            var list = await GetPagedListAsync<Setting>(page, itemsPerPage, keyValuePairs);

            return list;
        }
    }
}
