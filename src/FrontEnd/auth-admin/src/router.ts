import Vue from 'vue';
import Router from 'vue-router';
import Index from './pages/index.vue'
// 基础数据组件
import OrganizationList from './pages/base/organization/index.vue';
import UserList from './pages/base/user/index.vue'
import PositionList from './pages/base/position/index.vue'
import RoleList from './pages/base/role/index.vue'
// 系统设置组件
import ModuleList from './pages/system/module/index.vue';
import ApiList from './pages/system/api/index.vue'
import PermissionList from './pages/system/permission/index.vue'
import SettingList from './pages/system/setting/index.vue'
import SettingAdd from './pages/system/setting/add.vue'

Vue.use(Router);

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'index',
            component: Index
        },
        // 基础数据
        {
            path: '/base/organization',
            name: 'organization-list',
            component: OrganizationList
        },
        {
            path: '/base/user',
            name: 'user-list',
            component: UserList
        },
        {
            path: '/base/position',
            name: 'position-list',
            component: PositionList
        },
        {
            path: '/base/role',
            name: 'role-list',
            component: RoleList
        },
        // 系统设置
        {
            path: '/system/module',
            name: 'module-list',
            component: ModuleList
        },
        {
            path: '/system/api',
            name: 'api-list',
            component: ApiList
        },
        {
            path: '/system/permission',
            name: 'permission-list',
            component: PermissionList
        },
        {
            path: '/system/setting',
            name: 'setting-list',
            component: SettingList
        },
        {
            path: '/system/setting/add',
            name: 'setting-add',
            component: SettingAdd
        }
    ]
});