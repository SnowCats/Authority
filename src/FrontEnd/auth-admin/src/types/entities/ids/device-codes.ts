interface IDeviceCodes {
  userCode: string;
  deviceCode: string;
  subjectId: string;
  sessionId: string;
  clientId: string;
  description: string;
  creationTime: string;
  expiration: string;
  data: string;
}

export default class DeviceCodes implements IDeviceCodes {
  userCode: string = '';
  deviceCode: string = '';
  subjectId: string = '';
  sessionId: string = '';
  clientId: string = '';
  description: string = '';
  creationTime: string = '';
  expiration: string = '';
  data: string = '';
}