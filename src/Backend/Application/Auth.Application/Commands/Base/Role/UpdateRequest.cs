using System;
using Auth.Dto.Base;
using MediatR;

namespace Auth.Application.Commands.Base.Role
{
    /// <summary>
    /// 更新角色请求
    /// </summary>
    public class UpdateRequest : IRequest<bool>
    {
        /// <summary>
        /// 角色类
        /// </summary>
        public RoleDto RoleDto { get; set; }
    }
}
