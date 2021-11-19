interface IIdentityResourceClaim {
  id?: string;
  type: string;
  identityResourceId: string;
}

export default class IdentityResourceClaim implements IIdentityResourceClaim {
  id?: string;
  type: string = '';
  identityResourceId: string = '';
}