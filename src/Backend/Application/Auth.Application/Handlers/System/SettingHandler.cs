using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.System.Setting;
using Auth.Dto.System;
using Auth.Entity.System;
using Auth.IRepository.ISetting;
using Auth.SeedWork.DapperExtensions;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers.System
{
    /// <summary>
    /// 数据字典处理服务
    /// </summary>
    public class SettingHandler : IRequestHandler<CreateRequest, Guid?>,
        IRequestHandler<UpdateRequest, bool>,
        IRequestHandler<DeleteRequest, bool>,
        IRequestHandler<PagedRequest, IEnumerable<SettingDto>>,
        IRequestHandler<QueryListRequest, IEnumerable<SettingDto>>
    {
        /// <summary>
        /// 数据字典仓储接口
        /// </summary>
        private readonly ISettingRepository SettingRepository;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingHandler(ISettingRepository settingRepository, IMapper mapper)
        {
            this.mapper = mapper;
            SettingRepository = settingRepository;
        }

        /// <summary>
        /// 新增数据字典Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid?> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            Setting setting = mapper.Map<Setting>(request.SettingDto);

            // 判断Value是否已存在
            if(await SettingRepository.HasValueAsync<Setting>(nameof(setting.Value), setting.Value))
            {
                return null;
            }
            else
            {
                await SettingRepository.InsertAsync(setting);
                return setting.ID;
            }
        }

        /// <summary>
        /// 删除数据字典Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            Setting setting = mapper.Map<Setting>(request.SettingDto);

            bool result = await SettingRepository.DeleteAsync(setting);

            return result;
        }

        /// <summary>
        /// 更新数据字典Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            Setting setting = mapper.Map<Setting>(request.SettingDto);
            bool result = await SettingRepository.UpdateAsync(setting);

            return result;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SettingDto>> Handle(PagedRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Setting> list = await SettingRepository.GetPagedList(request, new List<string>(), new { });
            IEnumerable<SettingDto> dtos = mapper.Map<IEnumerable<SettingDto>>(list);

            return dtos;
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SettingDto>> Handle(QueryListRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Setting> list = await SettingRepository.GetListAsync<Setting>("");
            IEnumerable<SettingDto> dtos = mapper.Map<IEnumerable<SettingDto>>(list);

            return dtos;
        }
    }
}
