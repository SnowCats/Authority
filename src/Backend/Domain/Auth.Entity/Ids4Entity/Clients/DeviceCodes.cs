using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    /// <summary>
    /// device_codes
    /// </summary>
    [Table("device_codes")]
    public class DeviceCodes
    {
        /// <summary>
        /// UserCode
        /// </summary>
        [ExplicitKey]
        public string UserCode { get; set; }

        /// <summary>
        /// DeviceCode
        /// </summary>
        public string DeviceCode { get; set; }

        /// <summary>
        /// SubjectId
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CreationTime
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Expiration
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
    }
}
