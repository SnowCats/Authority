interface IClaimType {
  id?:string;
  name: string;
  valueType: number;
  valueTypeAsString: string;
  description: string;
  required: boolean;
  isStatic: boolean;
}

export default class ClaimType implements IClaimType {
  id?: string = '';
  name: string = '';
  valueType: number = 0;
  valueTypeAsString: string = '';
  description: string = '';
  required: boolean = false;
  isStatic: boolean = true;
}