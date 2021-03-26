<template>
  <div class="v-widget">
    <v-card>
      <v-app-bar color="transparent" flat dense v-if="enableHeader">
        <v-toolbar-title>
          <span class="title">{{ title }}</span>
        </v-toolbar-title>
        <v-spacer></v-spacer>
        <slot name="widget-header-action"></slot>
      </v-app-bar>
      <v-divider v-if="enableHeader"></v-divider>
      <v-card-text :class="contentBg">
        <slot name="widget-content"></slot>
      </v-card-text>
    </v-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

// props
const VWidgetProps = Vue.extend({
  // props
  props: {
    title: {
      type: String,
    },
    enableHeader: {
      type: Boolean,
      default: true,
    },
    contentBg: {
      type: String,
      default: "white",
    },
  },
});

// 组件注入
@Component
export default class VWidget extends VWidgetProps {
  // data
}
</script>

<style lang="scss" scoped>
.v-widget {
  margin-bottom: 15px;

  .title {
    font-size: 0.8em !important;
  }
}
</style>