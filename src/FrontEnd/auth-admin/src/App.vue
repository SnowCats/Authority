<template>
  <v-app>
    <v-main>
      <Layout></Layout>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import Layout from "./components/layouts/Layout.vue";

export default Vue.extend({
  name: "App",

  components: {
    Layout,
  },

  data: () => ({
    //
  }),
});
</script>
