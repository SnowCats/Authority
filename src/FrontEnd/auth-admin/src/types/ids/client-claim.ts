interface IClientClaim {
  id?: number;
  type: string;
  value: string;
  clientId: number;
}

export default class ClientClaim implements IClientClaim {
  id?: number | undefined;
  type: string = '';
  value: string = '';
  clientId: number = 0;
}