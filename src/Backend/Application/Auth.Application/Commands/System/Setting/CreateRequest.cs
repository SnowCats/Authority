using System;
using Auth.Dtos.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 新增数据字典请求
    /// </summary>
    public class CreateRequest : IRequest<Guid?>
    {
        /// <summary>
        /// 数据字典Dto
        /// </summary>
        public SettingDto SettingDto { get; set; }
    }
}
