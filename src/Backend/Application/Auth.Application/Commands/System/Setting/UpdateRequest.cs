using System;
using Auth.Dtos.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 更新数据字典请求
    /// </summary>
    public class UpdateRequest : IRequest<bool>
    {
        /// <summary>
        /// 数据字典Dto
        /// </summary>
        public SettingDto SettingDto { get; set; }
    }
}
