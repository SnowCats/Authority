using System;
using System.Collections.Generic;
using Auth.Application.Common;
using Auth.Dtos.System;
using Dapper.Contrib.Plus;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    /// <summary>
    /// 更新数据字典请求
    /// </summary>
    public class QueryPagedListFilter : IRequest<PagedList<SettingDto>>
    {
        /// <summary>
        /// 分页条件
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// 上级字典值
        /// </summary>
        [Conditional(ConditionalType.Equal)]
        public string ParentValue { get; set; }

        /// <summary>
        /// 字典文本
        /// </summary>
        [Conditional(ConditionalType.Like)]
        public string Text { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [Conditional(ConditionalType.Equal)]
        public string Value { get; set; }
    }
}
