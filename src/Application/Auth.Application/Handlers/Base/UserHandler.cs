using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Handlers.Base.UserCommand;
using Auth.Application.Interfaces.IBase;
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
    public class UserHandler : IUserHandler,
        IRequestHandler<CreateCommand, Response>,
        IRequestHandler<UpdateCommand, Response>
    {
        /// <summary>
        /// User Repository
        /// </summary>
        private readonly IUserRepository UserRepository;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);

            return new Response { Data = await UserRepository.InsertAsync(user), StatusCode = 200, Message = "Success" };
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);

            return new Response { Data = await UserRepository.UpdateAsync(user), StatusCode = 200, Message = "Success" };
        }
    }
}
