// Setting
interface SettingInterface {
    id: String
    parentValue: String
    value: String
    text: String
    status: Number
    notes: String
}

export default class Setting implements SettingInterface {
    id: String = ''
    parentValue: String = ''
    value: String = ''
    text: String = ''
    status: Number = 1  // 默认启用
    notes: String = ''
} 