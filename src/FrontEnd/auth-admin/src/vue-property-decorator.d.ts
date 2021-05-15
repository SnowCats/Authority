import Vue from 'vue';

declare module 'vue/types/vue' {
  interface Vue {
    $confirm: Promise;
    $alert: Promise;
  }
}