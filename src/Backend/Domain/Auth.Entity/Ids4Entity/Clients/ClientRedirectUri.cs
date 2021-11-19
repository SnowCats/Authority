using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("client_redirect_uris")]
    public class ClientRedirectUri : SeedWork.Entity
    {
        /// <summary>
        /// 回调URL
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// 客户端Id
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
