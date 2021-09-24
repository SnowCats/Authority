interface IApiResource {
  id?: number;
  enabled: boolean;
  name: string;
  displayName: string;
  description: string;
  allowedAccessT: string;
  showInDiscover: boolean;
  created: string;
  updated: string;
  lastAccessed: string;
  nonEditable: boolean;
}

export default class ApiResource implements IApiResource {
  id?: number | undefined;
  enabled: boolean = true;
  name: string = '';
  displayName: string = '';
  description: string = '';
  allowedAccessT: string = '';
  showInDiscover: boolean = false;
  created: string = '';
  updated: string = '';
  lastAccessed: string = '';
  nonEditable: boolean = false;

}