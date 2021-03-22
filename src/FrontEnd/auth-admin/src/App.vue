<template>
  <v-app>
    <Layout></Layout>
    <v-main>
      <v-container fluid>
        <router-view :key="$route.fullPath"></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Layout from "./components/layouts/layout.vue";

// 组件注入
@Component({
  components: {
    Layout,
  },
})
export default class App extends Vue {}
</script>

<style lang="less" scoped>
.v-main {
  .container.container--fluid {
    height: 100vh;
    padding-top: 64px + 15px;
  }
}
</style>