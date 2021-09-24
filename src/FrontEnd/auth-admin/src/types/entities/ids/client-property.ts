interface IClientProperty {
  id?: number;
  key: string;
  value: string;
  clientId: number;
}

export default class ClientProperty implements IClientProperty {
  id?: number | undefined;
  key: string = '';
  value: string = '';
  clientId: number = 0;
}