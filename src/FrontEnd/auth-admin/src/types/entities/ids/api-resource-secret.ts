interface IApiResourceSecret {
  id?: number;
  description: string;
  value: string;
  expiration: string;
  type: string;
  created: string;
  apiResourceId: number;
}

export default class ApiResourceSecret implements IApiResourceSecret {
  id?: number | undefined;
  description: string = '';
  value: string = '';
  expiration: string = '';
  type: string = '';
  created: string = '';
  apiResourceId: number = 0;
}