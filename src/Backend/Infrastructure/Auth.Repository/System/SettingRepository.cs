﻿using System;
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
            using(UnitOfWork.Connection)
            {
                var list = await GetPagedListAsync<Setting>(UnitOfWork.Connection, pagination.Page, pagination.ItemsPerPage);

                return list;
            }
        }
    }
}
