<template>
  <div id="app">
    <danho-header :me="me" :links="links" @navigate="onNavigate"/>
    <router-view :me="me" />
    <danho-footer :me="me" />
  </div>
</template>

<script>
import DanhoHeader from './components/Shared/DanhoHeader.vue';
import DanhoFooter from './components/Shared/DanhoFooter.vue';

import { Me } from 'models';
import { contact, locationCollection, spareTime, projects } from './data';

const me = new Me(locationCollection, contact, spareTime, projects);
const links = ['Home', 'About', 'Projects', 'Plan'];

export default {
  name: 'App',
  components: {
    DanhoHeader, 
    DanhoFooter
  },
  data: () => ({ 
    me, 
    links
  }),
  methods: {
    /**@param {string} direction */
    onNavigate(direction) {
      this.$router.push(`/${direction}`);
    }
  }
}
</script>

<style>

</style>
