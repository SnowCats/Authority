using System;
using System.Collections.Generic;
using Auth.Dto.System;
using MediatR;

namespace Auth.Application.Commands.System.Setting
{
    public class QueryListRequest : IRequest<IEnumerable<SettingDto>>
    {
        
    }
}
