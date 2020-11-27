import Axios, { AxiosInstance } from 'axios';

// axios配置
const axios: AxiosInstance = Axios.create({
    baseURL: process.env.VUE_APP_URL,
    headers: {
        'Cache-Control': 'no-cache',
        // 添加Token
    },
    withCredentials: true,
    timeout: 5000
});
console.log(process.env.VUE_APP_URL)
// 全局配置
axios.defaults.baseURL = process.env.VUE_APP_URL;
//axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
axios.defaults.headers.post['Content-Type'] = 'application/json';

// 请求拦截
Axios.interceptors.request.use(function (config) {
    // Do something before request is sent
    // if(config.method === 'post') {
    //     config.data = JSON.stringify(config.data);
    // }
    return config;
}, function (error) {
    console.log(error.response)
    // Do something with request error
    return Promise.reject(error);
});

// 响应拦截
Axios.interceptors.response.use(function (response) {
    // Do something with response data
    return response;
}, function (error) {
    // Do something with response data
    return Promise.reject(error);
});

export default {
    axios
};