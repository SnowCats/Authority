import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import router from './router';
import './assets/variables/app.scss';
import './assets/mixins/mixins.scss';

Vue.config.productionTip = false;

// i18n
import VueI18n from 'vue-i18n';

Vue.use(VueI18n);

// i18n
import { messages, defaultLocale } from '@/i18n';
import store from './store';

export const i18n = new VueI18n({
  messages,
  locale: defaultLocale,
  fallbackLocale: defaultLocale
});

// 
new Vue({
  i18n,
  store,
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
