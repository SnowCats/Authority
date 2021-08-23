using System;

namespace Auth.Dtos.Ids4
{
    public class ClientRedirectUriDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClientId { get; set; }
    }
}
