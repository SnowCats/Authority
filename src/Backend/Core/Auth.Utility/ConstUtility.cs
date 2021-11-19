using System;
namespace Auth.Utility
{
    public static class ConstUtility
    {
        /// <summary>
        /// ClientSecret类型
        /// </summary>
        public static class ClientSecretType
        {
            public const string SharedSecret = "SharedSecret";

            public const string X509Thumbprint = "X509Thumbprint";
        }
    }
}
