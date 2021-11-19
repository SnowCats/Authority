interface IIdentityResourceProperty {
  id?: string;
  type: string;
  identityResourceId: string;
}

export default class IdentityResourceProperty implements IIdentityResourceProperty {
  id?: string;
  type: string = '';
  identityResourceId: string = '';
}