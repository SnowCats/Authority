interface IClientCorsOrigin {
  id?: string;
  origin: string;
  clientId: string;
}

export default class ClientCorsOrigin implements IClientCorsOrigin {
  id?: string;
  origin: string = '';
  clientId: string = '';
}