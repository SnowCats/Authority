using System;

namespace Auth.Dtos.Ids4
{
    /// <summary>
    /// identity_resources
    /// </summary>
    public class IdentityResourceDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Emphasize
        /// </summary>
        public bool Emphasize { get; set; }

        /// <summary>
        /// ShowInDiscover
        /// </summary>
        public bool ShowInDiscover { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Updated
        /// </summary>
        public string Updated { get; set; }

        /// <summary>
        /// NonEditable
        /// </summary>
        public bool NonEditable { get; set; }
    }
}
