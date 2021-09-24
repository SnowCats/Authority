interface IClientIdPRestriction {
  id?: number;
  provider: string;
  clientId: number;
}

export default class ClientIdPRestriction implements IClientIdPRestriction {
  id?: number | undefined;
  provider: string = '';
  clientId: number = 0;
}