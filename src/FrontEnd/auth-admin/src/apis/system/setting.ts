import Setting from '@/types/system/setting';
import axios from '../../plugins/axios';

// 分页
function getPagedList(json: any): any {
  axios.post('/api/Setting/GetPagedList', json).then(res => {
    return res.data;
  });
}

// 新增
function insert(setting: Setting): any {
  axios.post('/api/Setting/Insert', setting).then(res => {
    return res.data;
  });
}


// 更新
function update(setting: Setting): any {
  axios.put('/api/Setting/Update', setting).then(res => {
    return res.data;
  });
}

// 删除
function remove(json: any): any {
  axios.delete('/api/Setting/Delete', json).then(res => {
    return res.data;
  })
}

// 查询列表
function getList(json: any): any {
  axios.post('/api/Setting/GetList', json).then(res => {
    return res.data;
  })
}

export {
  getPagedList,
  insert,
  update,
  remove,
  getList,
}