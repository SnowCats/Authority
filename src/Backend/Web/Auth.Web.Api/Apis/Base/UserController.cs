using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Application.Commands.Base.User;
using Auth.Dtos.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Web.Api.Apis.Base
{
    /// <summary>
    /// 用户信息接口
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// MediatR
        /// </summary>
        private readonly IMediator Mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> InsertAsync(UserDto userDto)
        {
            try
            {
                CreateRequest request = new CreateRequest { UserDto = userDto };
                var response = await Mediator.Send(request);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
