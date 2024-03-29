interface IApiScope {
  id?: string;
  enabled: boolean;
  name: string;
  displayName: string;
  description: string;
  required: boolean;
  emphasize: boolean;
  showInDiscoveryDocument: any;
}

export default class ApiScope implements IApiScope {
  id?: string;
  enabled: boolean = true;
  name: string = '';
  displayName: string = '';
  description: string = '';
  required: boolean = false;
  emphasize: boolean = false;
  showInDiscoveryDocument: any = null;
}