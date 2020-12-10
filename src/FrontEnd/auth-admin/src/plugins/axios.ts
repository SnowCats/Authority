import Vue from 'vue';
import axios, { AxiosInstance } from 'axios';

// 全局配置
axios.defaults.baseURL = process.env.VUE_APP_URL;
//axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
axios.defaults.headers.post['Content-Type'] = 'application/json';

// 请求拦截
axios.interceptors.request.use(function (config) {
    config.withCredentials = false;
    // Do something before request is sent
    debugger;
    if(config.method === 'post') {
        config.data = JSON.stringify(config.data);
    }
    return config;
}, function (error) {
    console.log(error.response)
    // Do something with request error
    return Promise.reject(error);
});

// 响应拦截
axios.interceptors.response.use(function (response) {
    // Do something with response data
    return response;
}, function (error) {
    // Do something with response data
    return Promise.reject(error);
});

export default {
    axios
};