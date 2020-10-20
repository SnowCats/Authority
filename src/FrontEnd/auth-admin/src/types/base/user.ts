// User
interface UserInterface {
    id: String
    name: String
    gender: any
    userName: String
    password: String
    email: String
    wechat: String
    telephone: String
    phone: String
    positionID: String
    address: String
    status: Number
    notes: String
}

export default class User implements UserInterface {
    id: String = ''
    name: String = ''
    gender: any = null
    userName: String = ''
    password: String = ''
    email: String = ''
    wechat: String = ''
    telephone: String = ''
    phone: String = ''
    positionID: String = ''
    address: String = ''
    status: Number = 1  // 默认启用
    notes: String = ''
}
