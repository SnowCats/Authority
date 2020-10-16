const list = [{
        title: "基础数据",
        group: "base",
        icon: "mdi-database",
        active: true,
        items: [{
                name: "organization",
                title: "组织信息",
                icon: "mdi-account-group"
            },
            {
                name: "user",
                title: "用户信息",
                icon: "mdi-account"
            },
            {
                name: "position",
                title: "岗位信息",
                icon: "mdi-account-circle"
            },
            {
                name: "role",
                title: "角色信息",
                icon: "mdi-account-box"
            },
        ]
    },
    {
        title: "系统设置",
        group: "system",
        icon: "mdi-cog",
        active: false,
        items: [{
                name: "module",
                title: "模块信息",
                icon: "mdi-menu"
            },
            {
                name: "api",
                title: "接口信息",
                icon: "mdi-api"
            },
            {
                name: "permission",
                title: "权限信息",
                icon: "mdi-shield-account"
            },
            {
                name: "setting",
                title: "数据字典",
                icon: "mdi-book"
            }
        ]
    }
];

export default list;