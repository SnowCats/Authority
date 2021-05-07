<template>
  <v-alert color="#C51162" dark border="right">
    <v-icon>mdi-check</v-icon> 
    blandit leo ut odio. Morbi mattis ullamcorper velit. Donec orci lectus, aliquam ut, faucibus non, euismod id, nulla. In ut
    quam vitae odio lacinia tincidunt.
  </v-alert>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({})
export default class Alert extends Vue {
  @Prop() type: String = 'success';
}
</script>

<style lang="scss" scoped>
.v-alert {
  position: fixed;
  top: 0;
  width: 100%;
  z-index: 10000;
  height: 64px;
  margin: 0 0;
  line-height: 30px;
}
</style>