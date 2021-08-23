using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientPostLogoutRedirectUriDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// PostLogoutRedirectUri
        /// </summary>
        public string PostLogoutRedirectUri { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
