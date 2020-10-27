using System;
using Auth.Dto.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 更新数据字典请求
    /// </summary>
    public class QueryRequest : IRequest<string>
    {
        /// <summary>
        /// 数据字典Dto
        /// </summary>
        public SettingDto SettingDto { get; set; }
    }
}
