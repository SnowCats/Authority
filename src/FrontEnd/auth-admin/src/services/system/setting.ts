import Setting from '@/types/entities/system/setting';
import axios from '../../plugins/axios';

let service = {
  // 分页
  getPagedList(json: any): Promise<any> {
    return axios.post('/api/Setting/GetPagedList', json);
  },
  // 新增
  insert(setting: Setting): Promise<any> {
    return axios.post('/api/Setting/Insert', setting);
  },
  // 更新
  update(setting: Setting): Promise<any> {
    return axios.put('/api/Setting/Update', setting);
  },
  // 删除
  delete(json: any): Promise<any> {
    return axios.delete('/api/Setting/Delete', { data: json });
  },
  // 查询列表
  getList(json: any): Promise<any> {
    return axios.post('/api/Setting/GetList', json);
  },
  // 查询单条记录
  get(id: string): Promise<any> {
    return axios.get('/api/Setting/Get/' + id);
  }
}

export default service;