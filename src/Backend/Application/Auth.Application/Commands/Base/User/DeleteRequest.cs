using System;
using Auth.Dtos.Base;
using MediatR;

namespace Auth.Application.Commands.Base.User
{
    /// <summary>
    /// 删除用户请求
    /// </summary>
    public class DeleteRequest : IRequest<bool>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
