const list = [{
    title: "基础数据",
    group: "base",
    icon: "mdi-database",
    active: true,
    items: [{
        name: "organization",
        title: "组织信息",
        icon: "mdi-account-group",
        href: "/base/organization",
    },
    {
        name: "user",
        title: "用户信息",
        icon: "mdi-account",
        href: "/base/user",
    },
    {
        name: "position",
        title: "岗位信息",
        icon: "mdi-account-circle",
        href: "/base/position",
    },
    {
        name: "role",
        title: "角色信息",
        icon: "mdi-account-box",
        href: "/base/role",
    }]
},
{
    title: "系统设置",
    group: "system",
    icon: "mdi-cog",
    active: false,
    items: [{
        name: "module",
        title: "模块信息",
        icon: "mdi-menu",
        href: "/system/module",
    },
    {
        name: "api",
        title: "接口信息",
        icon: "mdi-api",
        href: "/system/api",
    },
    {
        name: "permission",
        title: "权限信息",
        icon: "mdi-shield-account",
        href: "/system/permission",
    },
    {
        name: "setting",
        title: "数据字典",
        icon: "mdi-book",
        href: "/system/setting",
    }]
},
{
    title: "认证授权",
    group: "ids",
    icon: "mdi-shield-key",
    active: false,
    items: [{
        name: "client",
        title: "客户端",
        icon: "mdi-laptop",
        href: "/ids/client",
    }, {
        name: "identity-resource",
        title: "身份资源",
        icon: "mdi-identifier",
        href: "/ids/identity-resource",
    }, {
        name: "api-resource",
        title: "接口资源",
        icon: "mdi-api",
        href: "/ids/api-resource",
    }]
}];

export default list;