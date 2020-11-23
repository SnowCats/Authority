// User
interface UserInterface {
    id: String
    name: string
    gender: any
    userName: string
    password: string
    email: string
    wechat: string
    telephone: string
    phone: string
    positionID: string
    address: string
    status: number
    notes: string
}

export default class User implements UserInterface {
    id: string = ''
    name: string = ''
    gender: any = null
    userName: string = ''
    password: string = ''
    email: string = ''
    wechat: string = ''
    telephone: string = ''
    phone: string = ''
    positionID: string = ''
    address: string = ''
    status: number = 1  // 默认启用
    notes: string = ''
}
