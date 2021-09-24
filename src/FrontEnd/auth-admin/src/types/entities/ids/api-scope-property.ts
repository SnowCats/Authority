interface IApiScopeProperty {
  id?: number;
  key: string;
  value: string;
  scopeId: number;
}

export default class ApiScopeProperty implements IApiScopeProperty {
  id?: number | undefined;
  key: string = '';
  value: string = '';
  scopeId: number = 0;
}