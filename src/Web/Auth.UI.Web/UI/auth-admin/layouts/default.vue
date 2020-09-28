<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" app>
      <!-- menus -->
      <v-list-item>
        <v-list-item-avatar>
          <img src="https://randomuser.me/api/portraits/men/81.jpg" />
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title class="title"> Auth </v-list-item-title>
          <v-list-item-subtitle> 基础数据认证平台 </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list>
        <v-list-group
          v-for="item in items"
          :key="item.title"
          v-model="item.active"
          :prepend-icon="item.action"
          no-action
        >
          <template v-slot:activator>
            <v-list-item-content>
              <v-list-item-title v-text="item.title"></v-list-item-title>
            </v-list-item-content>
          </template>

          <v-list-item v-for="subItem in item.items" :href="subItem.url" :key="subItem.title" link>
            <v-list-item-content>
              <v-list-item-title
                v-text="subItem.title"
              ></v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-group>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar app>
      <!---->
      <v-app-bar-nav-icon></v-app-bar-nav-icon>
      <v-toolbar-title>Page Title</v-toolbar-title>
      <v-btn icon>
        <v-icon>mdi-heart</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
    </v-app-bar>
    <!-- Sizes your content based upon application components -->
    <v-main>
      <v-container fluid>
        <nuxt />
      </v-container>
    </v-main>
    <!-- Footer -->
    <v-footer app>
      <!---->
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    title: "Vuetify.js",
    drawer: true,
    items: [
      {
        action: "mdi-account",
        title: "基础数据",
        active: true,
        items: [
          { title: "组织架构", icon: "", url: "/base/organization" },
          { title: "用户信息", icon: "", url: "/base/user" },
          { title: "角色信息", icon: "", url: "/base/role" },
          { title: "岗位信息", icon: "", url: "/base/position" },
        ],
      },
      {
        action: "mdi-cog-outline",
        title: "系统设置",
        active: false,
        items: [
          { title: "接口信息", icon: "", url: "/system/api" },
          { title: "模块信息", icon: "", url: "/system/module" },
          { title: "权限信息", icon: "", url: "/system/permission" },
          { title: "数据字典", icon: "", url: "/system/setting" },
        ],
      },
    ],
  }),
};
</script>
