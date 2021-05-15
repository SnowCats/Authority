<template>
  <v-alert
    :type="type"
    :value="visible"
  >{{message}}</v-alert>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'

@Component({})
export default class Alert extends Vue {
  visible: Boolean = false;
  type: String = "warning";
  message: String = "默认消息";

  open(type: string, message: string, duration: number = 3000): void {
    this.type = type;
    this.message = message;
    this.visible = true;

    setTimeout(() => {
      this.visible = false;
    }, duration)
  }
}
</script>

<style lang="scss" scoped>

</style>