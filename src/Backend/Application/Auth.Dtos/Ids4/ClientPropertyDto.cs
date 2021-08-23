using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientPropertyDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public int ClientId { get; set; }
    }
}
