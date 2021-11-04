<template>
  <v-dialog v-model="visible">
    <v-card>
      <v-card-title class="headline">
        {{ title }}
      </v-card-title>
      <v-card-text>
        <slot name="content">
          <component :is="content"></component>
        </slot>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn :color="options.cancelColor" text @click.native="cancel">{{ options.cancelText }}</v-btn>
        <v-btn :color="options.okColor" text @click.native="agree">{{ options.okText }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({})
export default class Modal extends Vue {
  visible: Boolean = false;
  title: String = '';
  componentName: string = '';
  options: any = {
    width: 600,
    okText: 'OK',
    okColor: 'primary',
    cancelText: 'CANCEL',
    cancelColor: 'default',
  };
  resolve: Function = (value: boolean) => value;
  reject: Function = (value: boolean) => value;

  load(title: string, componentName: string, options: any): Promise<any> {
    this.visible = true;
    this.title = title;
    this.componentName = componentName;
    this.options = Object.assign(this.options, options);
    return new Promise((resolve: Function, reject: Function) => {
      this.resolve = resolve;
      this.reject = reject;
    });
  }

  agree(): void {
    this.resolve(true);
    this.visible = false;
  }

  cancel(): void {
    this.resolve(false);
    this.visible = false;
  }
}
</script>

<style lang="scss" scoped>
</style>