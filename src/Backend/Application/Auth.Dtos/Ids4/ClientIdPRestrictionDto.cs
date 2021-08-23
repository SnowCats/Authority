using System;

namespace Auth.Dtos.Ids4
{
    public class ClientIdPRestrictionDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Provider
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
