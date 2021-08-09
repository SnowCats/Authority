using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.Base.User;
using Auth.Entity.BaseEntity;
using Auth.IRepository;
using Auth.IRepository.IBase;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers.Base
{
    /// <summary>
    /// 用户处理服务
    /// </summary>
    public class UserHandler : IRequestHandler<CreateRequest, Guid>
    {
        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle服务
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            User user = mapper.Map<User>(request.UserDto);

            await UnitOfWork.User.InsertAsync(user);

            return user.Id;
        }
    }
}
