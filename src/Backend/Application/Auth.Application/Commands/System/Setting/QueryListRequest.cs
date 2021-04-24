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
        public string Value { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [FieldName("Text", ConditionalType.Equal)]
        public string _Text { get; set; }

        /// <summary>
        /// List
        /// </summary>
        public IList<string> List { get; set; }

        /// <summary>
        /// List
        /// </summary>
        public string[] StrList { get; set; }

        public IEnumerable<string> EnumerableList { get; set; }
    }
}
