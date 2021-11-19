interface IApiResourceSecret {
  id?: string;
  description: string;
  value: string;
  expiration: string;
  type: string;
  created: string;
  apiResourceId: string;
}

export default class ApiResourceSecret implements IApiResourceSecret {
  id?: string;
  description: string = '';
  value: string = '';
  expiration: string = '';
  type: string = '';
  created: string = '';
  apiResourceId: string = '';
}