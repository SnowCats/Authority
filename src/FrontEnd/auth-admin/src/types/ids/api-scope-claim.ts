interface IApiScopeClaim {
  id?: number;
  type: string;
  scopeId: number;
}

export default class ApiScopeClaim implements IApiScopeClaim {
  id?: number | undefined;
  type: string = '';
  scopeId: number = 0;
}