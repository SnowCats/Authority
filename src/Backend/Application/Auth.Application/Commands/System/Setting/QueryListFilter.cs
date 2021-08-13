using System;
using System.Collections.Generic;
using Auth.Dtos.System;
using Dapper.Contrib.Plus;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    public class QueryListFilter : IRequest<IEnumerable<SettingDto>>
    {
        /// <summary>
        /// Value
        /// </summary>
        [Conditional(ConditionalType.Equal)]
        public string Value { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Conditional(ConditionalType.Equal)]
        public string Text { get; set; }
    }
}
