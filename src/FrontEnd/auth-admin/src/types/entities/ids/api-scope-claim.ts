interface IApiScopeClaim {
  id?: string;
  type: string;
  scopeId: string;
}

export default class ApiScopeClaim implements IApiScopeClaim {
  id?: string;
  type: string = '';
  scopeId: string = '';
}