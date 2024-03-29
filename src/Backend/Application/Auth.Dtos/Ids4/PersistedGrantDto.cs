﻿using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// PersistedGrants
    /// </summary>
    public class PersistedGrantDto
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

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
        /// ConsumedTime
        /// </summary>
        public string ConsumedTime { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
    }
}
