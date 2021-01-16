using System;
using System.Collections.Generic;
using Auth.Dto.System;
using Auth.SeedWork.DapperExtensions;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 更新数据字典请求
    /// </summary>
    public class QueryRequest : Pagination, IRequest<IEnumerable<SettingDto>>
    {
        /// <summary>
        /// 上级字典值
        /// </summary>
        public string ParentValue { get; set; }

        /// <summary>
        /// 字典文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        public string Value { get; set; }
    }
}
