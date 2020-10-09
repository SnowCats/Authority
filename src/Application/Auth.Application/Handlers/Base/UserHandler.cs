using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Handlers.Base.UserCommand;
using Auth.Dto;
using Auth.Dto.Base;
using Auth.Entity.Base;
using Auth.IRepository.IBase;
using Auth.SeedWork;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers.Base
{
    /// <summary>
    /// UserHanlder
    /// </summary>
    public class UserHandler : IRequestHandler<CreateUserRequest, Guid>
    {
        /// <summary>
        /// User Repository
        /// </summary>
        private readonly IUserRepository UserRepository;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            User user = mapper.Map<User>(request.UserDto);

            await UserRepository.InsertAsync(user);

            return user.ID;
        }
    }
}
