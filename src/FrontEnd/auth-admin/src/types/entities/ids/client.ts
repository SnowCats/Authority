interface IClient {
  id?: number;  // 主键
  enabled: boolean; // 是否启用
  clientId: string; // 客户端Id
  protocolType: string; // 协议类型
  requireClientSecret: boolean; // 需要许可
  clientName: string; // 客户端名称
  description: string;  // 描述
  clientUri: string;  // 客户端Uri
  logoUri: string;  // 注销URL
  requireConsent: boolean;  // 需要许可
  allowRememberConsent: boolean;  // 允许记住许可
  alwaysIncludeUserClaimsInIdToken: boolean;  // 
  requirePkce: boolean; // 
  allowPlainTextPkce: boolean;  // 
  requireRequestObject: boolean;  // 需要请求对象
  allowAccessTokensViaBrowser: boolean; // 
  frontChannelLogoutUri: string;  // Front-Channel注销URL
  frontChannelLogoutSessionRequired: boolean; // 需要Front-Channel注销Session
  backChannelLogoutUri: string; // BackChannel注销URL
  backChannelLogoutSessionRequired: boolean;  // 需要Back-Channel注销Session
  allowOfflineAccess: boolean;  // 允许离线访问
  identityTokenLifetime: number;  // 
  allowedIdentityTokenSigningAlgorithms: string;
  accessTokenLifetime: number;
  authorizationCodeLifetime: number;
  consentLifetime: number;
  absoluteRefreshTokenLifetime: number;
  slidingRefreshTokenLifetime: number;
  refreshTokenUsage: number;
  updateAccessTokenClaimsOnRefresh: boolean;
  refreshTokenExpiration: number;
  accessTokenType: number;
  enableLocalLogin: boolean;
  includeJwtId: boolean;
  alwaysSendClientClaims: boolean;
  clientClaimsPrefix: string;
  pairWiseSubjectSalt: string;
  created: string;
  updated: string;
  lastAccessed: string;
  userSsoLifetime: number;
  userCodeType: string;
  deviceCodeLifetime: number;
  nonEditable: boolean;
}

export default class Client implements IClient {
  id?: number | undefined;
  enabled: boolean = true;
  clientId: string = '';
  protocolType: string = '';
  requireClientSecret: boolean = false;
  clientName: string = '';
  description: string = '';
  clientUri: string = '';
  logoUri: string = '';
  requireConsent: boolean = false;
  allowRememberConsent: boolean = true;
  alwaysIncludeUserClaimsInIdToken: boolean = false;
  requirePkce: boolean = false;
  allowPlainTextPkce: boolean = false;
  requireRequestObject: boolean = false;
  allowAccessTokensViaBrowser: boolean = false;
  frontChannelLogoutUri: string = '';
  frontChannelLogoutSessionRequired: boolean = true;
  backChannelLogoutUri: string = '';
  backChannelLogoutSessionRequired: boolean = true;
  allowOfflineAccess: boolean = true;
  identityTokenLifetime: number = 0;
  allowedIdentityTokenSigningAlgorithms: string = '';
  accessTokenLifetime: number = 0;
  authorizationCodeLifetime: number = 0;
  consentLifetime: number = 0;
  absoluteRefreshTokenLifetime: number = 0;
  slidingRefreshTokenLifetime: number = 0;
  refreshTokenUsage: number = 0;
  updateAccessTokenClaimsOnRefresh: boolean = false;
  refreshTokenExpiration: number = 0;
  accessTokenType: number = 0;
  enableLocalLogin: boolean = false;
  includeJwtId: boolean = false;
  alwaysSendClientClaims: boolean = false;
  clientClaimsPrefix: string = '';
  pairWiseSubjectSalt: string = '';
  created: string = '';
  updated: string = '';
  lastAccessed: string = '';
  userSsoLifetime: number = 0;
  userCodeType: string = '';
  deviceCodeLifetime: number = 0;
  nonEditable: boolean = false;
}