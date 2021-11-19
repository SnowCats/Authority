interface IApiScopeProperty {
  id?: string;
  key: string;
  value: string;
  scopeId: string;
}

export default class ApiScopeProperty implements IApiScopeProperty {
  id?: string;
  key: string = '';
  value: string = '';
  scopeId: string = '';
}