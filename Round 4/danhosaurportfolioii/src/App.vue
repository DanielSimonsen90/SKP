<template>
  <div id="app">
    <danho-header />
    <router-view />
    <danho-footer />
  </div>
</template>

<script>
import DanhoHeader from './components/Shared/DanhoHeader.vue';
import DanhoFooter from './components/Shared/DanhoHeader.vue';

import { Me } from 'models';
import { contact, locationCollection, spareTime, projects } from './data';

const me = new Me(locationCollection, contact, spareTime, projects);

export default {
  name: 'App',
  components: {
    DanhoHeader, 
    DanhoFooter
  },
  data: () => ({
    me
  })
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
