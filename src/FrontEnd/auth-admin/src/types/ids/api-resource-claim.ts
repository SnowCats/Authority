interface IApiResourceClaim {
  id?: number;
  type: string;
  apiResourceId: number;
}

export default class ApiResourceClaim implements IApiResourceClaim {
  id?: number | undefined;
  type: string = '';
  apiResourceId: number = 0;
}