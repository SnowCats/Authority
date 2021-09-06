interface IClientScope {
  id?: number;
  scope: string;
  clientId: number;
}

export default class ClientScope implements IClientScope {
  id?: number | undefined;
  scope: string = '';
  clientId: number = 0;
}