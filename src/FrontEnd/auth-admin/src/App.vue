<template>
  <v-app>
    <v-main>
      <Layout></Layout>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Layout from "./components/layouts/Layout.vue";

// 组件注入
@Component({
  components: {
    Layout
  }
})

export default class App extends Vue {
  
}

</script>

<style lang="less" scoped>
.container.container--fluid {
  padding-left: 256px + 12px;
  height: 100vh - 64px;
}
</style>