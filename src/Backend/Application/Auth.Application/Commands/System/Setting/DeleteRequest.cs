using System;
using Auth.Dto.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 删除数据字典请求
    /// </summary>
    public class DeleteRequest : IRequest<bool>
    {
        /// <summary>
        /// 数据字典Dto
        /// </summary>
        public SettingDto SettingDto { get; set; }
    }
}
