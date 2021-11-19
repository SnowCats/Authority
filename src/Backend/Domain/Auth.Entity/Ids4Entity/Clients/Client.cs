using System;
using System.Collections.Generic;
using Dapper.Contrib.Plus;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Auth.Entity.Ids4Entity
{
    [Table("clients")]
    public class Client : SeedWork.Entity
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 客户端Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>
        public string ProtocolType { get; set; } = ProtocolTypes.OpenIdConnect;

        /// <summary>
        /// 需要许可
        /// </summary>
        public bool RequireClientSecret { get; set; } = true;

        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 客户端Uri
        /// </summary>
        public string ClientUri { get; set; }

        /// <summary>
        /// LogoUri
        /// </summary>
        public string LogoUri { get; set; }

        /// <summary>
        /// 需要许可
        /// </summary>
        public bool RequireConsent { get; set; } = true;

        /// <summary>
        /// 允许记住许可
        /// </summary>
        public bool AllowRememberConsent { get; set; } = true;

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
        /// 需要请求对象
        /// </summary>
        public bool RequireRequestObject { get; set; }

        /// <summary>
        /// AllowAccessTokensViaBrowser
        /// </summary>
        public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// Front-Channel注销URL
        /// </summary>
        public string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// 需要Front-Channel注销Session
        /// </summary>
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// BackChannel注销URL
        /// </summary>
        public string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// 需要Back-Channel注销Session
        /// </summary>
        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// 允许离线访问
        /// </summary>
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// IdentityTokenLifetime
        /// </summary>
        public int IdentityTokenLifetime { get; set; } = 300;

        /// <summary>
        /// AllowedIdentityTokenSigningAlgorithms
        /// </summary>
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }

        /// <summary>
        /// AccessTokenLifetime
        /// </summary>
        public int AccessTokenLifetime { get; set; } = 3600;

        /// <summary>
        /// AuthorizationCodeLifetime
        /// </summary>
        public int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// ConsentLifetime
        /// </summary>
        public int? ConsentLifetime { get; set; }

        /// <summary>
        /// AbsoluteRefreshTokenLifetime
        /// </summary>
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        /// <summary>
        /// SlidingRefreshTokenLifetime
        /// </summary>
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        /// <summary>
        /// RefreshTokenUsage
        /// </summary>
        public int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;

        /// <summary>
        /// UpdateAccessTokenClaimsOnRefresh
        /// </summary>
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>
        /// RefreshTokenExpiration
        /// </summary>
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;

        /// <summary>
        /// AccessTokenType
        /// </summary>
        public int AccessTokenType { get; set; } = (int)IdentityServer4.Models.AccessTokenType.Jwt;

        /// <summary>
        /// EnableLocalLogin
        /// </summary>
        public bool EnableLocalLogin { get; set; } = true;

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
        public string ClientClaimsPrefix { get; set; } = "client_";

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
        public int? UserSsoLifetime { get; set; }

        /// <summary>
        /// UserCodeType
        /// </summary>
        public string UserCodeType { get; set; }

        /// <summary>
        /// DeviceCodeLifetime
        /// </summary>
        public int DeviceCodeLifetime { get; set; } = 300;

        /// <summary>
        /// NonEditable
        /// </summary>
        public bool NonEditable { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// ClientClaim
        /// </summary>
        [Computed]
        public IList<ClientClaim> Claims { get; set; }

        /// <summary>
        /// ClientCorsOrigin
        /// </summary>
        [Computed]
        public IList<ClientCorsOrigin> CorsOrigins { get; set; }

        /// <summary>
        /// ClientGrantType
        /// </summary>
        [Computed]
        public IList<ClientGrantType> GrantTypes { get; set; }

        /// <summary>
        /// ClientIdPRestriction
        /// </summary>
        [Computed]
        public IList<ClientIdPRestriction> PRestrictions { get; set; }

        /// <summary>
        /// ClientPostLogoutRedirectUri
        /// </summary>
        [Computed]
        public IList<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// ClientProperty
        /// </summary>
        [Computed]
        public IList<ClientProperty> Properties { get; set; }

        /// <summary>
        /// ClientRedirectUri
        /// </summary>
        [Computed]
        public IList<ClientRedirectUri> RedirectUris { get; set; }

        /// <summary>
        /// ClientScope
        /// </summary>
        [Computed]
        public IList<ClientScope> Scopes { get; set; }

        /// <summary>
        /// ClientSecret
        /// </summary>
        [Computed]
        public IList<ClientSecret> Secrets { get; set; }

        /// <summary>
        /// DeviceCodes
        /// </summary>
        [Computed]
        public IList<DeviceCodes> DeviceCodes { get; set; }

        /// <summary>
        /// PersistedGrants
        /// </summary>
        [Computed]
        public IList<PersistedGrant> PersistedGrants { get; set; }
    }
}
