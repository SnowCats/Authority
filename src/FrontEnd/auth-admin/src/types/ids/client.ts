interface IClient {
  id?: number;
  enabled: boolean;
  clientId: string;
  protocolType: string;
  requireClientSecret: boolean;
  clientName: string;
  description: string;
  clientUri: string;
  logoutUri: string;
  requireConsent: boolean;
  allowRememberConsent: boolean;
  alwaysIncludeUserClaimsInIdToken: boolean;
  requirePkce: boolean;
  allowPlainTextPkce: boolean;
  requireRequestObject: boolean;
  allowAccessTokensViaBrowser: boolean;
  frontChannelLogoutUri: string;
  frontChannelLogoutSessionRequired: boolean;
  backChannelLogoutUri: string;
  backChannelLogoutSessionRequired: boolean;
  allowOfflineAccess: boolean;
  identityTokenLifetime: number;
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
  logoutUri: string = '';
  requireConsent: boolean = false;
  allowRememberConsent: boolean = false;
  alwaysIncludeUserClaimsInIdToken: boolean = false;
  requirePkce: boolean = false;
  allowPlainTextPkce: boolean = false;
  requireRequestObject: boolean = false;
  allowAccessTokensViaBrowser: boolean = false;
  frontChannelLogoutUri: string = '';
  frontChannelLogoutSessionRequired: boolean = false;
  backChannelLogoutUri: string = '';
  backChannelLogoutSessionRequired: boolean = false;
  allowOfflineAccess: boolean = false;
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