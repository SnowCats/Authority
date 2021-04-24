using System;
using System.Collections.Generic;
using Auth.Dto.System;
using Dapper.Contrib.Plus;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    public class QueryListRequest : IRequest<IEnumerable<SettingDto>>
    {
        /// <summary>
        /// Value
        /// </summary>
        [Conditional(ConditionalType.LikeLeft)]
        public string Value { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Conditional(ConditionalType.LikeLeft)]
        public string Text { get; set; }
    }
}
