using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("client_redirect_uris")]
    public class ClientRedirectUri
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 回调URL
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// 客户端Id
        /// </summary>
        public int ClientId { get; set; }
    }
}
