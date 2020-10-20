﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Commands.Base.User;
using Auth.Entity.Base;
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
        /// Handle服务
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            User user = mapper.Map<User>(request.UserDto);

            Guid result = await UserRepository.InsertAsync(user);

            return result;
        }
    }
}
