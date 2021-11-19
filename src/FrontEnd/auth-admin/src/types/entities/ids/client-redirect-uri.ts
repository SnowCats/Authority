interface IClientRedirectUri {
  id?: string;
  redirectUri: string;
  clientId: string;
}

export default class ClientRedirectUri implements IClientRedirectUri {
  id?: string;
  redirectUri: string = '';
  clientId: string = '';
}