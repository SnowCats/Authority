import Setting from '@/types/system/setting';
import axios from '../../plugins/axios';

// 分页
function getPagedList(json: any): any {
  return axios.post('/api/Setting/GetPagedList', json);
}

// 新增
function insert(setting: Setting): any {
  return axios.post('/api/Setting/Insert', setting);
}


// 更新
function update(setting: Setting): any {
  return axios.put('/api/Setting/Update', setting);
}

// 删除
function remove(json: any): any {
  return axios.delete('/api/Setting/Delete', json);
}

// 查询列表
function getList(json: any): any {
  return axios.post('/api/Setting/GetList', json);
}

export {
  getPagedList,
  insert,
  update,
  remove,
  getList,
}