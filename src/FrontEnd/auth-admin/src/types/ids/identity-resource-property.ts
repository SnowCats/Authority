interface IIdentityResourceProperty {
  id?: number;
  type: string;
  identityResourceId: number;
}

export default class IdentityResourceProperty implements IIdentityResourceProperty {
  id?: number | undefined;
  type: string = '';
  identityResourceId: number = 0;
}