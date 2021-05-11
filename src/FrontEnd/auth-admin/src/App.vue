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
import { Vue, Component, Prop } from 'vue-property-decorator';
import Layout from './components/layouts/Layout.vue';

// 组件注入
@Component({
  components: {
    Layout
  },
})
export default class App extends Vue {}
</script>

<style lang="scss" scoped>
.v-main {
  .container.container--fluid {
    height: 100vh;
    padding-top: 64px + 15px;
  }
}

.v-alert {
  position: fixed;
  top: 0;
  width: 100%;
  z-index: 10000;
}
</style>