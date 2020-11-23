// Setting
interface SettingInterface {
    id: string
    parentValue: string
    value: string
    text: string
    status: number
    notes: string
}

export default class Setting implements SettingInterface {
    id: string = ''
    parentValue: string = ''
    value: string = ''
    text: string = ''
    status: number = 1  // 默认启用
    notes: string = ''
} 