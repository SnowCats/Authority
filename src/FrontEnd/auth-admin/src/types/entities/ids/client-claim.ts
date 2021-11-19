interface IClientClaim {
  id?: string;
  type: string;
  value: string;
  clientId: string;
}

export default class ClientClaim implements IClientClaim {
  id?: string;
  type: string = '';
  value: string = '';
  clientId: string = '';
}