using System;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Commands.Base.User
{
    /// <summary>
    /// 新增用户请求
    /// </summary>
    public class CreateRequest : IRequest<Guid>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
