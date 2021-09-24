// User
interface IUser {
    id?: string;
    name: string;
    gender: any;
    userName: string;
    password: string;
    email: string;
    wechat: string;
    telephone: string;
    phone: string;
    positionID: string;
    address: string;
    status: number;
    notes: string;
}

export default class User implements IUser {
    id?: string = ''
    name = ''
    gender: any = null
    userName = ''
    password = ''
    email = ''
    wechat = ''
    telephone = ''
    phone = ''
    positionID = ''
    address = ''
    status = 1  // 默认启用
    notes = ''
}
