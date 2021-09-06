interface IClientPostLogoutRedirectUri {
  id?: number;
  postLogoutRedirectUri: string;
  clientId: number;
}

export default class ClientPostLogoutRedirectUri implements IClientPostLogoutRedirectUri {
  id?: number | undefined;
  postLogoutRedirectUri: string = '';
  clientId: number = 0;
}