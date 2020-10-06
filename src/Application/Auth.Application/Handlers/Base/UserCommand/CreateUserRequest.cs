using System;
using Auth.Dto;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Handlers.Base.UserCommand
{
    public class CreateUserRequest : IRequest<Guid>
    {
        /// <summary>
        /// UserDto
        /// </summary>
        public UserDto UserDto { get; set; }
    }
}
