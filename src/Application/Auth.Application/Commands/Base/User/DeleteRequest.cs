using System;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Commands.User
{
    /// <summary>
    /// 删除用户
    /// </summary>
    public class DeleteRequest : IRequest<bool>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
