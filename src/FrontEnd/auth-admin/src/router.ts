import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

// 解决路由重复控制台报错问题
const originalPush = VueRouter.prototype.push;
VueRouter.prototype.push = function (location: string): any {
    return (originalPush.call(this, location) as any).catch((err: any) => err);
};

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        // 登录
        {
            path: '/login',
            name: 'login',
            component: () => import('@/pages/home/login.vue')
        },
        // Dashboard
        {
            path: '/',
            name: 'Dashboard',
            component: () => import('@/pages/index.vue')
        },
        // 基础数据
        {
            // 组织信息
            path: '/base/organization',
            name: 'organization-list',
            component: () => import('@/pages/base/organization/index.vue')
        },
        {
            // 用户信息
            path: '/base/user',
            name: 'user-list',
            component: () => import('@/pages/base/user/index.vue')
        },
        {
            // 岗位信息
            path: '/base/position',
            name: 'position-list',
            component: () => import('@/pages/base/position/index.vue')
        },
        {
            // 角色信息
            path: '/base/role',
            name: 'role-list',
            component: () => import('@/pages/base/role/index.vue')
        },
        // 系统设置
        {
            // 模块信息
            path: '/system/module',
            name: 'module-list',
            component: () => import('@/pages/system/module/index.vue')
        },
        {
            // Api信息
            path: '/system/api',
            name: 'api-list',
            component: () => import('@/pages/system/api/index.vue')
        },
        {
            // 权限信息
            path: '/system/permission',
            name: 'permission-list',
            component: () => import('@/pages/system/permission/index.vue')
        },
        {
            // 数据字典信息
            path: '/system/setting',
            name: 'setting-list',
            component: () => import('@/pages/system/setting/index.vue')
        },
        {
            // 数据字典信息新增
            path: '/system/setting/add',
            name: 'setting-add',
            component: () => import('@/pages/system/setting/add.vue')
        },
        {
            // 数据字典信息编辑
            path: '/system/setting/edit/:id',
            name: 'setting-edit',
            component: () => import('@/pages/system/setting/edit.vue')
        }
    ]
});