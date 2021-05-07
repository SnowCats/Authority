<template>
  <div>
    <v-navigation-drawer app fixed>
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
          <v-list-group
            v-if="menu.group"
            v-model="menu.active"
            :key="menu.title"
            sub-group
          >
            <template v-slot:activator>
              <v-list-item-title>{{ menu.title }}</v-list-item-title>
            </template>
            <v-list-item
              v-for="(item, i) in menu.items"
              :key="i"
              link
              @click="to(item.href)"
            >
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
    <v-app-bar color="primary" dark>
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
      <!--Set Language-->
      <v-menu transition="scroll-y-transition" open-on-hover offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn class="translation" icon v-bind="attrs" v-on="on">
            <v-icon>mdi-google-translate</v-icon>
          </v-btn>
        </template>

        <v-list dense>
          <v-list-item link @click="setLanguage(language.CN)"
            >中文简体</v-list-item
          >
          <v-list-item link @click="setLanguage(language.EN)"
            >English</v-list-item
          >
        </v-list>
      </v-menu>
      <!---->
    </v-app-bar>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import { Locales } from "../../i18n/locales";
import Menus from "../../services/menu";

// 组件注入
@Component({
  components: {},
})
export default class Layout extends Vue {
  // data
  menus = Menus;
  language = {
    CN: Locales.CN,
    EN: Locales.EN,
  };
  /* Methods */
  // 跳转
  to(href: string): void {
    if(this.$route.name !== 'navbar') {
      this.$router.push(href);
    }
  }
  // 切换语言
  setLanguage(lang: Locales): void {
    this.$store.commit("setLanguage", lang);
    console.log(this.$store.state.language);
  }
}
</script>

<style lang="scss" scoped>
button.translation {
  position: absolute;
  right: 15px;
}

.v-navigation-drawer {
  box-shadow: 0px 3px 1px -2px rgba(0, 0, 0, 0.2),
    0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12);
    padding-top: 64px;
}

.v-app-bar {
  position: fixed;
  z-index: 2020;
}
</style>
