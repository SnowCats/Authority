import VueRouter, { Route } from 'vue-router'
// 扩充
declare module 'vue/types/vue' {
  interface Vue {
    $router: VueRouter;
    $route: Route;
    $alert: any;
  }
}