interface IClientGrantType {
  id?: number;
  grantType: string;
  clientId: number;
}

export default class ClientGrantType implements IClientGrantType {
  id?: number | undefined;
  grantType: string = '';
  clientId: number = 0;
}