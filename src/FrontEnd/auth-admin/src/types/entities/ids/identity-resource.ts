interface IIdentityResource {
  id?: string;
  enabled: boolean;
  name: string;
  displayName: string;
  description: string;
  required: boolean;
  emphasize: boolean;
  showInDiscover: boolean;
  created: string;
  updated: string;
  nonEditable: boolean;
}

export default class IdentityResource implements IIdentityResource {
  id?: string;
  enabled: boolean = true;
  name: string = '';
  displayName: string = '';
  description: string = '';
  required: boolean = false;
  emphasize: boolean = false;
  showInDiscover: boolean = false;
  created: string = '';
  updated: string = '';
  nonEditable: boolean = false;
}