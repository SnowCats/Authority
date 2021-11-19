interface IApiResourceClaim {
  id?: string;
  type: string;
  apiResourceId: string;
}

export default class ApiResourceClaim implements IApiResourceClaim {
  id?: string;
  type: string = '';
  apiResourceId: string = '';
}