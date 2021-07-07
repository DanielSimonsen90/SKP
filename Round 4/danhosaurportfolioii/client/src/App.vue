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
        :language="language" :languageValue="languageValue" :projectType="projectType" :projectLanguage="projectLanguage"
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
import { contact, locationCollection, projects, languages } from './data';

const me = new Me(locationCollection, contact, projects);

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
    languageValue: localStorage.getItem('language') || 'Dansk'
  }),
  computed: {
    links() {
      return this.language.get('links');
    },
    language() {
      return languages.get(this.languageValue);
    }
  },
  methods: {
    /**@param {string} direction */
    onNavigate(direction) {
      if (window.location.href.endsWith(direction)) return;
      this.$router.push(`/${direction}`);
    },
    onProjectFilterChange(type, value) {
      this[type] = value;
    },
    onLanguageChanged(language) {
      if (!languages.has(language)) return;

      localStorage.setItem('language', language);
      this.languageValue = language;
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
  box-sizing: border-box;
}

header, footer {
  background: $background-secondary;
}
header { top: 0; position: sticky }
footer { bottom: 0 }

#app > * { 
  // position: absolute; 
  z-index: 1;
}

#main-content {
  display: block;
  top: 15%;
  text-align: center;
  margin: 0 auto;
  min-height: 76vh;
  overflow: auto;
  @include height-width(100%, 100%);
}

@include scroll-bar();
@include popup-modal();

</style>
