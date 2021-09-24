interface IApiResourceScope {
  id?: number;
  scope: string;
  apiResourceId: number;
}

export default class ApiResourceScope implements IApiResourceScope {
  id?: number | undefined;
  scope: string = '';
  apiResourceId: number = 0;
}