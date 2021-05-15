using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.System.Setting;
using Auth.Application.Common;
using Auth.Dto.System;
using Auth.Entity.System;
using Auth.IRepository.ISetting;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers.System
{
    /// <summary>
    /// 数据字典处理服务
    /// </summary>
    public class SettingHandler :
        IRequestHandler<GetRequest, SettingDto>,
        IRequestHandler<CreateRequest, Guid?>,
        IRequestHandler<UpdateRequest, bool>,
        IRequestHandler<DeleteRequest, bool>,
        IRequestHandler<QueryPagedListRequest, Pagination<SettingDto>>,
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
            if (await SettingRepository.HasValueAsync<Setting>(nameof(setting.Value), setting.Value))
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
        public async Task<Pagination<SettingDto>> Handle(QueryPagedListRequest request, CancellationToken cancellationToken)
        {
            IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs = new List<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>>();

            IEnumerable<Setting> list = await SettingRepository.GetPagedListAsync<Setting>(request.Page, request.ItemsPerPage, keyValuePairs);
            long count = await SettingRepository.CountAsync<Setting>(keyValuePairs);

            // 如果有记录
            if (count > 0)
            {
                // 查询并关联上级节点的文本值
                IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValues = new List<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>>
                {
                    new KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>(
                        new KeyValuePair<string, dynamic>(nameof(request.Value), list.Where(s => !string.IsNullOrWhiteSpace(s.ParentValue)).Select(s => s.ParentValue).ToList()),
                        ConditionalType.In)
                };

                IEnumerable<Setting> parentList = await SettingRepository.GetListAsync<Setting>(keyValues);

                if (parentList.Any())
                {
                    foreach (var item in parentList)
                    {
                        list.Where(s => s.ParentValue == item.Value).FirstOrDefault().Superior.Text = item.Text;
                        list.Where(s => s.ParentValue == item.Value).FirstOrDefault().Superior.Value = item.Value;
                    }
                }
            }

            IEnumerable<SettingDto> dtos = mapper.Map<IEnumerable<SettingDto>>(list);
            return new Pagination<SettingDto> { Count = count, Page = request.Page, ItemsPerPage = request.ItemsPerPage, List = dtos };
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SettingDto>> Handle(QueryListRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Setting> list = await SettingRepository.GetListAsync<Setting, QueryListRequest>(request);
            IEnumerable<SettingDto> dtos = mapper.Map<IEnumerable<SettingDto>>(list);

            return dtos;
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SettingDto> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            Setting setting = await SettingRepository.GetAsync<Setting>(request.ID.Value);
            SettingDto settingDto = mapper.Map<SettingDto>(setting);

            return settingDto;
        }
    }
}
