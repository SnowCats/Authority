interface IClientSecret {
  id?: number;
  description: string;
  value: string;
  expiration: string;
  type: string;
  created: string;
  clientId: number;
}

export default class ClientSecret implements IClientSecret {
  id?: number | undefined;
  description: string = '';
  value: string = '';
  expiration: string = '';
  type: string = 'SharedSecret';
  created: string = '';
  clientId: number = 0;
}