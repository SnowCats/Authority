interface IClientPostLogoutRedirectUri {
  id?: string;
  postLogoutRedirectUri: string;
  clientId: string;
}

export default class ClientPostLogoutRedirectUri implements IClientPostLogoutRedirectUri {
  id?: string;
  postLogoutRedirectUri: string = '';
  clientId: string = '';
}