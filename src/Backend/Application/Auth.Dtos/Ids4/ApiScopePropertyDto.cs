using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiScopePropertyDto
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
        /// ScopeId
        /// </summary>
        public int ScopeId { get; set; }
    }
}
