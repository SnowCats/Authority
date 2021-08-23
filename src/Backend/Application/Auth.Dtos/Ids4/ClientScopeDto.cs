using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// client_scopes
    /// </summary>
    public class ClientScopeDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Scope
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
