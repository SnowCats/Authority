using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.Base.Role;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers.Base
{
    /// <summary>
    /// 角色处理服务
    /// </summary>
    public class RoleHandler : IRequestHandler<CreateRequest, Guid>
    {
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public RoleHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle服务
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
