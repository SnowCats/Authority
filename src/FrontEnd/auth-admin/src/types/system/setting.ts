// Setting
interface ISetting {
    parentValue: string;
    value: string;
    text: string;
    status: number;
    notes: string;
}

export default class Setting implements ISetting {
    parentValue = '';
    value = '';
    text = '';
    status = 1;  // 默认启用
    notes = '';
} 