import Vue from 'vue'
import VueRouter from 'vue-router'
import AsyncComputed from 'vue-async-computed';
import App from './App.vue'

Vue.config.productionTip = false
Vue.use(VueRouter);
Vue.use(AsyncComputed);

import { routes } from './data';

new Vue({
  router: new VueRouter({ routes, mode: 'history' }),
  render: h => h(App),
}).$mount('#app')