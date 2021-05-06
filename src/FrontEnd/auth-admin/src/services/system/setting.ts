import Setting from '@/types/system/setting';
import axios from '../../plugins/axios';

let service = {
  // 分页
  getPagedList(json: any): any {
    return axios.post('/api/Setting/GetPagedList', json);
  },
  // 新增
  insert(setting: Setting): any {
    return axios.post('/api/Setting/Insert', setting);
  },
  // 更新
  update(setting: Setting): any {
    return axios.put('/api/Setting/Update', setting);
  },
  // 删除
  delete(json: any): any {
    return axios.delete('/api/Setting/Delete', json);
  },
  // 查询列表
  getList(json: any): any {
    return axios.post('/api/Setting/GetList', json);
  },
  // 查询单条记录
  get(id: string): any {
    return axios.get('/api/Setting/Get/' + id);
  }
}

export default service;