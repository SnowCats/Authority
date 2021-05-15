<template>
  <v-app>
    <v-layout></v-layout>
    <v-main>
      <v-container fluid>
        <router-view :key="$route.fullPath"></router-view>
      </v-container>
    </v-main>
    <confirm ref="confirm"></confirm>
    <alert ref="alert"></alert>
  </v-app>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import VLayout from '@/components/layouts/VLayout.vue';
import Confirm from '@/components/dialogs/Confirm.vue';
import Alert from '@/components/dialogs/Alert.vue';
// 组件注入
@Component({
  components: {
    VLayout,
    Confirm,
    Alert
  },
})
export default class App extends Vue {
  $refs!: any;

  mounted() {
    this.$root.$confirm = this.$refs.confirm.open;
    this.$root.$alert = this.$refs.alert.open;
  }
}
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