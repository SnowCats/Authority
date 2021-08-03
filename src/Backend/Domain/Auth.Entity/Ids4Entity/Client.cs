using System;
using Dapper.Contrib.Plus;

namespace Auth.Entity.Ids4Entity
{
    [Table("clients")]
    public class Client
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
        /// ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ProtocolType
        /// </summary>
        public string ProtocolType { get; set; }

        /// <summary>
        /// RequireClientSecret
        /// </summary>
        public bool RequireClientSecret { get; set; }

        /// <summary>
        /// ClientName
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ClientUri
        /// </summary>
        public string ClientUri { get; set; }

        /// <summary>
        /// LogoUri
        /// </summary>
        public string Logouri { get; set; }

        /// <summary>
        /// RequireConsent
        /// </summary>
        public bool RequireConsent { get; set; }

        /// <summary>
        /// AllowRememberConsent
        /// </summary>
        public bool AllowRememberConsent { get; set; }

        /// <summary>
        /// AlwaysIncludeUserClaimsInIdToken
        /// </summary>
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>
        /// RequirePkce
        /// </summary>
        public bool RequirePkce { get; set; }

        /// <summary>
        /// AllowPlainTextPkce
        /// </summary>
        public bool AllowPlainTextPkce { get; set; }

        /// <summary>
        /// RequireRequestObject
        /// </summary>
        public bool RequireRequestObject { get; set; }

        /// <summary>
        /// AllowAccessTokensViaBrowser
        /// </summary>
        public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// FrontChannelLogoutUri
        /// </summary>
        public string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// FrontChannelLogoutSessionRequired
        /// </summary>
        public bool FrontChannelLogoutSessionRequired { get; set; }

        /// <summary>
        /// BackChannelLogoutUri
        /// </summary>
        public string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// BackChannelLogoutSessionRequired
        /// </summary>
        public bool BackChannelLogoutSessionRequired { get; set; }

        /// <summary>
        /// AllowOfflineAccess
        /// </summary>
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// IdentityTokenLifetime
        /// </summary>
        public int IdentityTokenLifetime { get; set; }

        /// <summary>
        /// AllowedIdentityTokenSigningAlgorithms
        /// </summary>
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }

        /// <summary>
        /// AccessTokenLifetime
        /// </summary>
        public int AccessTokenLifetime { get; set; }

        /// <summary>
        /// AuthorizationCodeLifetime
        /// </summary>
        public int AuthorizationCodeLifetime { get; set; }

        /// <summary>
        /// ConsentLifetime
        /// </summary>
        public int ConsentLifetime { get; set; }

        /// <summary>
        /// AbsoluteRefreshTokenLifetime
        /// </summary>
        public int AbsoluteRefreshTokenLifetime { get; set; }

        /// <summary>
        /// SlidingRefreshTokenLifetime
        /// </summary>
        public int SlidingRefreshTokenLifetime { get; set; }

        /// <summary>
        /// RefreshTokenUsage
        /// </summary>
        public int RefreshTokenUsage { get; set; }

        /// <summary>
        /// UpdateAccessTokenClaimsOnRefresh
        /// </summary>
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>
        /// RefreshTokenExpiration
        /// </summary>
        public int RefreshTokenExpiration { get; set; }

        /// <summary>
        /// AccessTokenType
        /// </summary>
        public int AccessTokenType { get; set; }

        /// <summary>
        /// EnableLocalLogin
        /// </summary>
        public bool EnableLocalLogin { get; set; }

        /// <summary>
        /// IncludeJwtId
        /// </summary>
        public bool IncludeJwtId { get; set; }

        /// <summary>
        /// AlwaysSendClientClaims
        /// </summary>
        public bool AlwaysSendClientClaims { get; set; }

        /// <summary>
        /// ClientClaimsPrefix
        /// </summary>
        public string ClientClaimsPrefix { get; set; }

        /// <summary>
        /// PairWiseSubjectSalt
        /// </summary>
        public string PairWiseSubjectSalt { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Updated
        /// </summary>
        public string Updated { get; set; }

        /// <summary>
        /// LastAccessed
        /// </summary>
        public string LastAccessed { get; set; }

        /// <summary>
        /// UserSsoLifetime
        /// </summary>
        public int UserSsoLifetime { get; set; }

        /// <summary>
        /// UserCodeType
        /// </summary>
        public string UserCodeType { get; set; }

        /// <summary>
        /// DeviceCodeLifetime
        /// </summary>
        public int DeviceCodeLifetime { get; set; }

        /// <summary>
        /// NonEditable
        /// </summary>
        public bool NonEditable { get; set; }

        /// <summary>
        /// ClientClaim
        /// </summary>
        [Computed]
        public ClientClaim ClientClaim { get; set; }

        /// <summary>
        /// ClientCorsOrigin
        /// </summary>
        [Computed]
        public ClientCorsOrigin ClientCorsOrigin { get; set; }

        /// <summary>
        /// ClientGrantType
        /// </summary>
        [Computed]
        public ClientGrantType ClientGrantType { get; set; }

        /// <summary>
        /// ClientIdPRestriction
        /// </summary>
        [Computed]
        public ClientIdPRestriction ClientIdPRestriction { get; set; }

        /// <summary>
        /// ClientPostLogoutRedirectUri
        /// </summary>
        [Computed]
        public ClientPostLogoutRedirectUri ClientPostLogoutRedirectUri { get; set; }

        /// <summary>
        /// ClientProperty
        /// </summary>
        [Computed]
        public ClientProperty ClientProperty { get; set; }

        /// <summary>
        /// ClientRedirectUri
        /// </summary>
        [Computed]
        public ClientRedirectUri ClientRedirectUri { get; set; }

        /// <summary>
        /// ClientScope
        /// </summary>
        [Computed]
        public ClientScope ClientScope { get; set; }

        /// <summary>
        /// ClientSecret
        /// </summary>
        [Computed]
        public ClientSecret ClientSecret { get; set; }

        /// <summary>
        /// DeviceCodes
        /// </summary>
        [Computed]
        public DeviceCodes DeviceCodes { get; set; }
    }
}
