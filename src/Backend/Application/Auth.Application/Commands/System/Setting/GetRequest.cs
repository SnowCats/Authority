using System;
using Auth.Dto.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    public class GetRequest : IRequest<SettingDto>
    {
        /// <summary>
        /// 数据字典Dto
        /// </summary>
        public Guid? ID { get; set; }
    }
}
