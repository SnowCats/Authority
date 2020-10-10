using System;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Commands.Base.User
{
    /// <summary>
    /// 更新用户
    /// </summary>
    public class UpdateRequest : IRequest<bool>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
