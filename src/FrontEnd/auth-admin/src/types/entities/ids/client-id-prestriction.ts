interface IClientIdPRestriction {
  id?: string;
  provider: string;
  clientId: string;
}

export default class ClientIdPRestriction implements IClientIdPRestriction {
  id?: string;
  provider: string = '';
  clientId: string = '';
}