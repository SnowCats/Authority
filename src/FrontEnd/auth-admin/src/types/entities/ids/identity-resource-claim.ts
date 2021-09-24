interface IIdentityResourceClaim {
  id?: number;
  type: string;
  identityResourceId: number;
}

export default class IdentityResourceClaim implements IIdentityResourceClaim {
  id?: number | undefined;
  type: string = '';
  identityResourceId: number = 0;
}