interface IApiResourceProperty {
  id?: number;
  key: string;
  vaue: string;
  apiResourceId: number;
}

export default class ApiResourceProperty implements IApiResourceProperty {
  id?: number | undefined;
  key: string = '';
  vaue: string = '';
  apiResourceId: number = 0;
}