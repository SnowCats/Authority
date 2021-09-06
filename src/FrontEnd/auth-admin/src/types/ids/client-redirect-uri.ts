interface IClientRedirectUri {
  id?: number;
  redirectUri: string;
  clientId: number;
}

export default class ClientRedirectUri implements IClientRedirectUri {
  id?: number | undefined;
  redirectUri: string = '';
  clientId: number = 0;
}