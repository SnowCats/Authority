// User
interface User {
    id: String
    name: String
    gender: Number
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

export default class UserInfo implements User {
    id: String = ''
    name: String = ''
    gender: Number = 1
    userName: String = ''
    password: String = ''
    email: String = ''
    wechat: String = ''
    telephone: String = ''
    phone: String = ''
    positionID: String = ''
    address: String = ''
    status: Number = 1
    notes: String = ''
}
