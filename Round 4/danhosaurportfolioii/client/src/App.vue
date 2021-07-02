<template>
  <div id="app">
    <danho-header 
      :me="me" :links="links" 
      @navigate="onNavigate"

      :all="all" :language="language" :projectType="projectType" :filterTitle="filterTitle"
      @project-filter-change="onProjectFilterChange"
    />
    <content id="main-content">
      <router-view :me="me" @navigate="onNavigate"
        :all="all" :language="language" :projectType="projectType"
      />
    </content>
    <danho-footer :me="me" :links="links" @navigate="onNavigate" />
  </div>
</template>

<script>
import DanhoHeader from './components/Shared/DanhoHeader.vue';
import DanhoFooter from './components/Shared/DanhoFooter.vue';

import { Me } from 'models';
import { contact, locationCollection, spareTime, projects } from './data';

const me = new Me(locationCollection, contact, spareTime, projects);
// const links = ['Home', 'About', 'Projects', 'Plan'];
const links = ['Hjem', 'Om', 'Projekter', 'Plan'];

export default {
  name: 'App',
  components: {
    DanhoHeader, 
    DanhoFooter
  },
  data: () => ({ 
    me, 
    links,

    filterTitle: 'Projekt Filter',
    all: 'Alle',
    language: null,
    projectType: null
  }),
  methods: {
    /**@param {string} direction */
    onNavigate(direction) {
      if (window.location.href.endsWith(direction)) return;
      this.$router.push(`/${direction}`);
    },
    onProjectFilterChange(type, value) {
      this[type] = value;
      console.log({
        language: this.language,
        projectType: this.projectType
      })
    }
  }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/mixins';
@import '@/scss/partials';

body {
  background: $background;
  color: $color;
}

header, footer {
  background: $background-secondary;
}

#app > * {
  position: fixed;
}

#main-content {
  display: block;
  top: 15%;
  text-align: center;
  margin: 0 auto;
  min-height: 76vh;
  overflow: auto;
  height: 75%;
  width: 99%;
}

/* #region Scrollbar */
::-webkit-scrollbar {
  width: 8px;
}
::-webkit-scrollbar-track {
  @extend %hoverable;

  background: lighten($background-secondary, $theme-difference / 2);

  &:hover {
    background: lighten($background-secondary, $theme-difference);
  }
}
::-webkit-scrollbar-thumb {
  @extend %hoverable;

  background: darken($background, $theme-difference);

  &:hover{
    background: $theme-secondary;
  }
}
/* #endregion */


</style>
