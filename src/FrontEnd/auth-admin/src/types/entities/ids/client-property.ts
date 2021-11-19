interface IClientProperty {
  id?: string;
  key: string;
  value: string;
  clientId: string;
}

export default class ClientProperty implements IClientProperty {
  id?: string;
  key: string = '';
  value: string = '';
  clientId: string = '';
}