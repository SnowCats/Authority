import Vue from 'vue';
import Alert from "./Alert.vue";

const AlertComponent = Vue.extend(Alert);
let instance: any = null;

export default {
  init(options: any) {
    if(!instance) {
      instance = new AlertComponent({
        el: document.createElement('div')
      })
    }

    // instance.type = typeof options === 'string' ? options : options.type || '';
    // instance.icon = typeof options === 'string' ? options : options.icon || '';
    // instance.message = typeof options === 'string' ? options : options.message || '';

    document.querySelector("#app")?.appendChild(instance.$el);
  }
}