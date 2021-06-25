using System;
using Auth.Dtos.Base;
using MediatR;

namespace Auth.Application.Commands.Base.Role
{
    /// <summary>
    /// 删除角色请求
    /// </summary>
    public class DeleteRequest : IRequest<bool>
    {
        /// <summary>
        /// 角色类
        /// </summary>
        public RoleDto RoleDto { get; set; }
    }
}
