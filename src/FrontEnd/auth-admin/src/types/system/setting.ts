// Setting
interface SettingInterface {
    parentValue: string;
    value: string;
    text: string;
    status: number;
    notes: string;
}

export default class Setting implements SettingInterface {
    parentValue = '';
    value = '';
    text = '';
    status = 1;  // 默认启用
    notes = '';
} 