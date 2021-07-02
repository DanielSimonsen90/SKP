<template>
  <div id="app">
    <danho-header 
      :me="me" :links="links" 
      @navigate="onNavigate"

      :language="language"

      :projectLanguage="projectLanguage" :projectType="projectType"
      @project-filter-change="onProjectFilterChange"
    />
    <content id="main-content">
      <router-view :me="me" @navigate="onNavigate"
        :language="language" :projectType="projectType" :projectLanguage="projectLanguage"
      />
    </content>
    <danho-footer 
      :me="me" :links="links" 
      @navigate="onNavigate" 

      :language="language" :languageValue="languageValue"
      @language-change="onLanguageChanged"
    />
  </div>
</template>

<script>
import DanhoHeader from './components/Shared/DanhoHeader.vue';
import DanhoFooter from './components/Shared/DanhoFooter.vue';

import { Me } from 'models';
import { contact, locationCollection, spareTime, projects, languages } from './data';

const me = new Me(locationCollection, contact, spareTime, projects);

export default {
  name: 'App',
  components: {
    DanhoHeader, 
    DanhoFooter
  },
  data: () => ({ 
    me, 
    projectLanguage: null,
    projectType: null,
    languageValue: 'Dansk',
    language: languages.get('Dansk')
  }),
  computed: {
    links() {
      return this.language.get('links');
    },
  },
  methods: {
    /**@param {string} direction */
    onNavigate(direction) {
      if (window.location.href.endsWith(direction)) return;
      this.$router.push(`/${direction}`);
    },
    onProjectFilterChange(type, value) {
      this[type] = value;
      console.log(type, value)
    },
    onLanguageChanged(language) {
      if (!languages.has(language)) return;

      this.languageValue = language;
      this.language = languages.get(language);
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
