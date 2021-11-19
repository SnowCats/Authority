interface IClientGrantType {
  id?: string;
  grantType: string;
  clientId: string;
}

export default class ClientGrantType implements IClientGrantType {
  id?: string;
  grantType: string = '';
  clientId: string = '';
}