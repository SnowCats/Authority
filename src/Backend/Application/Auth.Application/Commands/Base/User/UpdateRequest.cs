using System;
using Auth.Dtos.Base;
using MediatR;

namespace Auth.Application.Commands.Base.User
{
    /// <summary>
    /// 更新用户请求
    /// </summary>
    public class UpdateRequest : IRequest<bool>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
