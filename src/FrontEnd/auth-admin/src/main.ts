import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import axios from './plugins/axios';
import VueAxios from 'vue-axios';
import router from './router';
import './assets/variables/app.scss';
import './assets/mixins/mixins.scss';

Vue.config.productionTip = false;

// i18n
import VueI18n from 'vue-i18n';

Vue.use(VueI18n);
Vue.use(VueAxios, axios);
// i18n
import { messages, defaultLocale } from '@/i18n';
import store from './store';

export const i18n = new VueI18n({
  messages,
  locale: defaultLocale,
  fallbackLocale: defaultLocale
});

// 全局变量
Vue.prototype.$confirm = () => {};

// Vue实例
new Vue({
  i18n,
  store,
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
