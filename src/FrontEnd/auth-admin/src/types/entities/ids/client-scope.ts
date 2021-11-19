interface IClientScope {
  id?: string;
  scope: string;
  clientId: string;
}

export default class ClientScope implements IClientScope {
  id?: string;
  scope: string = '';
  clientId: string = '';
}