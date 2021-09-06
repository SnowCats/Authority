interface IClientCorsOrigin {
  id?: number;
  origin: string;
  clientId: number;
}

export default class ClientCorsOrigin implements IClientCorsOrigin {
  id?: number | undefined;
  origin: string = '';
  clientId: number = 0;
}