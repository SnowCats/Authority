const list = [{
        title: "基础数据",
        group: "base",
        icon: "mdi-cog-outline",
        active: true,
        items: [{
                name: "organization",
                title: "组织信息",
                icon: "mdi-folder"
            },
            {
                name: "user",
                title: "用户信息",
                icon: "mdi-folder"
            },
            {
                name: "position",
                title: "岗位信息",
                icon: "mdi-folder"
            },
            {
                name: "role",
                title: "角色信息",
                icon: "mdi-folder"
            },
        ]
    },
    {
        title: "系统设置",
        group: "system",
        icon: "mdi-cog-outline",
        active: false,
        items: [{
                name: "module",
                title: "模块信息",
                icon: "mdi-folder"
            },
            {
                name: "api",
                title: "接口信息",
                icon: "mdi-folder"
            },
            {
                name: "permission",
                title: "权限信息",
                icon: "mdi-folder"
            },
            {
                name: "setting",
                title: "数据字典",
                icon: "mdi-folder"
            }
        ]
    }
];

export default list;