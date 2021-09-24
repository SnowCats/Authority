interface IPersistedGrant {
  key: string;
  type: string;
  subjectId: string;
  sessionId: string;
  clientId: string;
  description: string;
  creationTime: string;
  expiration: string;
  consumedTime: string;
  data: string;
}

export default class PersistedGrant implements IPersistedGrant {
  key: string = '';
  type: string = '';
  subjectId: string = '';
  sessionId: string = '';
  clientId: string = '';
  description: string = '';
  creationTime: string = '';
  expiration: string = '';
  consumedTime: string = '';
  data: string = '';
}