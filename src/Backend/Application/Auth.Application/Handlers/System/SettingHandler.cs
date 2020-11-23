using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.System.Setting;
using Auth.Entity.System;
using Auth.IRepository.ISetting;
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
        IRequestHandler<QueryRequest, string>
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
                Guid result = await SettingRepository.InsertAsync(setting);
                return result;
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
            //var result1 = SettingRepository.GetPagedList();

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
        public async Task<string> Handle(QueryRequest request, CancellationToken cancellationToken)
        {
            //var result = SettingRepository.GetPagedList();

            return await Task.FromResult("Result");
        }
    }
}
