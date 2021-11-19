interface IApiResourceProperty {
  id?: string;
  key: string;
  vaue: string;
  apiResourceId: string;
}

export default class ApiResourceProperty implements IApiResourceProperty {
  id?: string;
  key: string = '';
  vaue: string = '';
  apiResourceId: string = '';
}