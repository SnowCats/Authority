using System;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Commands.Base.Role
{
    /// <summary>
    /// 新增角色请求
    /// </summary>
    public class CreateRequest : IRequest<Guid>
    {
        /// <summary>
        /// 角色类
        /// </summary>
        public RoleDto RoleDto { get; set; }
    }
}
