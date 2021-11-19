interface IApiResourceScope {
  id?: string;
  scope: string;
  apiResourceId: string;
}

export default class ApiResourceScope implements IApiResourceScope {
  id?: string;
  scope: string = '';
  apiResourceId: string = '';
}