using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Application.Handlers.Base.UserCommand;
using Auth.Dto;
using Auth.Dto.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.UI.Web.Apis.System.v1
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
                CreateUserRequest request = new CreateUserRequest { UserDto = userDto };
                var response = await Mediator.Send(request);

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
