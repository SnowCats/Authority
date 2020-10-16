<template>
  <div>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />

        <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
          width="100"
        />
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
        text
      >
        <span class="mr-2">Latest Release</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>
    <v-card class="mx-auto drawer" width="256" tile>
      <v-navigation-drawer permanent>
        <v-list class="menu-list">
          <v-list-item link>
            <v-list-item-avatar>
              <v-img src="https://cdn.vuetifyjs.com/images/john.png"></v-img>
            </v-list-item-avatar>
            <v-list-item-content>
              <v-list-item-title class="title"> John Leider </v-list-item-title>
              <v-list-item-subtitle>john@vuetifyjs.com</v-list-item-subtitle>
            </v-list-item-content>

            <v-list-item-action>
              <v-icon>mdi-menu-down</v-icon>
            </v-list-item-action>
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <v-list dense expand>
          <template v-for="menu in menus">
            <v-list-group v-if="menu.group" v-model="menu.active" :key="menu.title" sub-group>
              <template v-slot:activator>
                <v-list-item-title>{{ menu.title }}</v-list-item-title>
              </template>
              <v-list-item v-for="(item, i) in menu.items" :key="i" link>
                <v-list-item-icon>
                  <v-icon v-text="item.icon" small></v-icon>
                </v-list-item-icon>
                <v-list-item-title v-text="item.title"></v-list-item-title>
              </v-list-item>
            </v-list-group>
            <v-list-item v-else :key="menu.title">{{ menu.title }}</v-list-item>
          </template>
        </v-list>
      </v-navigation-drawer>
    </v-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Menus from "../../apis/menu";

@Component
export default class Layout extends Vue {
  // data
  menus: any = Menus;
}
</script>

<style lang="less" scoped>
.drawer {
  position: absolute;
  height: 100vh;
  top: -64px;
}

.drawer .menu-list {
  margin-top: 64px;
}
</style>
