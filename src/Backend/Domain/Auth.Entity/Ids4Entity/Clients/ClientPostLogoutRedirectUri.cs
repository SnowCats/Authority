using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("client_post_logout_redirect_uris")]
    public class ClientPostLogoutRedirectUri : SeedWork.Entity
    {
        /// <summary>
        /// Signout Url
        /// </summary>
        public string PostLogoutRedirectUri { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
    }
}
