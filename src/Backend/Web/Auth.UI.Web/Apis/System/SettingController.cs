using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Application.Commands.System.Setting;
using Auth.Application.Common;
using Auth.Dto.System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.UI.Web.Apis.System
{
    /// <summary>
    /// 数据字典接口
    /// </summary>
    public class SettingController : ApiController
    {
        /// <summary>
        /// MediatR
        /// </summary>
        private readonly IMediator Mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SettingDto> GetAsync(Guid id)
        {
            GetRequest request = new GetRequest { ID = id };
            SettingDto response = await Mediator.Send(request);

            return response;
        }

        /// <summary>
        /// 新增数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid?> InsertAsync(SettingDto settingDto)
        {
            CreateRequest request = new CreateRequest { SettingDto = settingDto };
            Guid? response = await Mediator.Send(request);

            return response;
        }

        /// <summary>
        /// 更新数据字典
        /// </summary>
        /// <param name="settingDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateAsync(SettingDto settingDto)
        {
            UpdateRequest request = new UpdateRequest { SettingDto = settingDto };
            bool response = await Mediator.Send(request);

            return response;
        }

        /// <summary>
        /// 删除数据字典
        /// </summary>
        /// <param name="settingDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteAsync(SettingDto settingDto)
        {
            DeleteRequest request = new DeleteRequest { SettingDto = settingDto };
            bool response = await Mediator.Send(request);

            return response;
        }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="settingDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Pagination<SettingDto>> GetPagedListAsync(QueryPagedListRequest request)
        {
            Pagination<SettingDto> response = await Mediator.Send(request);

            return response;
        }

        /// <summary>
        /// 查询字典列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> GetListAsync(QueryListRequest request)
        {
            IEnumerable<SettingDto> response = await Mediator.Send(request);

            return response;
        }
    }
}
