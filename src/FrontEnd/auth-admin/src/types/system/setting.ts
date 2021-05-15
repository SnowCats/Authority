import * as uuid from 'uuid';

// Setting
interface ISetting {
    id: string;
    parentValue?: string;
    value?: string;
    text?: string;
    status?: number;
    notes?: string;
    superiorValue: string;
    superiorText: string;
}

export default class Setting implements ISetting {
    id = uuid.v4();
    parentValue = '';
    value = '';
    text = '';
    status = 1;  // 默认启用
    notes = '';
    superiorValue = '';
    superiorText = '';
} 