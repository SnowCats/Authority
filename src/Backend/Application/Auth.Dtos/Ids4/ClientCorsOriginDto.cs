using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// ClientCorsOrgins
    /// </summary>
    public class ClientCorsOriginDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
