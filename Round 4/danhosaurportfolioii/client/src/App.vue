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
      <router-view :me="me" :projects="projects"
        :language="language" :languageValue="languageValue" 
        :projectType="projectType" :projectLanguage="projectLanguage"
        
        @navigate="onNavigate" @refresh="refreshProjects"
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

import Vue from 'vue';
import { Me, ProjectCollection } from 'danhosaurportfolio-models';
import { contact, locationCollection, API, languages } from './data';

export default {
  name: 'App',
  components: { DanhoHeader, DanhoFooter },
  mounted() {
    this.refreshProjects();
  },
  data: () => ({ 
    me: new Me(locationCollection, contact, new ProjectCollection(contact.github, locationCollection)),
    projectLanguage: null,
    projectType: null,
    languageValue: localStorage.getItem('language') || this.$route.path.toLowerCase().includes('home') ? 'English' : 'Dansk'
  }),
  computed: {
    links() {
      return this.language.get('links');
    },
    language() {
      return languages.get(this.languageValue);
    },
    projects() {
      return this.me.projects;
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
    },
    async refreshProjects() {
      const projects = await API.getProjects();
      const me = new Me(locationCollection, contact, new ProjectCollection(
        contact.github, locationCollection
      ).append(...projects).sort((a, b) => a._id - b._id));

      Vue.set(this, 'me', me);
    }
  }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/mixins';
@import '@/scss/partials';

#app {
  position: fixed;
  @include height-width(100%, 100%);

  > header, > footer { background: $background-secondary; }
  > header { top: 0; position: sticky }
  > footer { bottom: 0; position: absolute; }

  > * {
    z-index: 1;
  }
}

body {
  background: $background;
  color: $color;
  box-sizing: border-box;
  margin: 0;
}

#main-content {
  @include max-height-width(79vh, unset);
  @include height-width(100%, 100%);
  display: block;
  top: 15%;
  text-align: center;
  margin: 0 auto;
  font-size: 18px;

  & > * {
    min-height: inherit;
    max-height: inherit;
  }
}

@include scroll-bar();
@include popup-modal();

content {
  overflow: auto;
  display: block;
}

label {
  width: 100%;
  display: block;
  text-align: left;

  b { margin: 0 10px; }
}

input, textarea {
  background-color: lighten($background-secondary, $theme-difference / 1.2);
  color: darken($color, $theme-difference);
  resize: none;
  padding: 2px;
  border-radius: $radius / 1.5;
  
  &:hover, &:focus {
    background-color: lighten($background-secondary, $theme-difference * 1.1);
    color: lighten($color, $theme-difference * 5);
    
    &::placeholder { color: darken($color, $theme-difference * 3); }
  }
}

button, input[type=file] {
    @extend %hoverable-background;
    @extend %hoverable-color;
    @extend %shadow-me;
    @extend %clickable;

    border-radius: $radius / 1.5;
    background: $background-secondary;
    margin: 1%;
}

fieldset {
  @extend %hoverable-border;
  @extend %shadow-me;
  @extend %rounded;

  display: inline;

  background-color: $fieldset-background;
  border-color: $theme-tertiary;

  word-wrap: break-word;
  margin: 5px;

    
  &:hover {
    border-color: $theme-secondary;

    legend {
      @extend %hoverable-color;

      color: $theme-primary !important;
    }
  }
}
legend {
  color: $theme-secondary;
  font-weight: bold;
  font-size: 150%;


  &:hover {
    color: $theme-primary;
  }
}

:root {
  --theme-difference: 10%;
  --theme-primary: #ff5e00;
  --theme-secondary: lighten(var(--theme-primary), var(--theme-difference));
  --theme-tertiary: lighten(var(--theme-secondary), var(--theme-difference));

  --background: rgb(var(--background-input), var(--background-input), var(--background-input));
  --background-secondary: rgb(var(--background-secondary-input), var(--background-secondary-input), var(--background-secondary-input));
  --background-hover: lighten(var(--background-secondary), 3%);
  --background-hoverable: darken(var(--background-secondary), 2%);

  --color: #ddd;
  --color-hover: lighten(var(--color), 5%);
  --color-hoverable: darken(var(--color-hover), var(--theme-difference) * 5);
  --color-click-me: rgb(155, 179, 211);

  --non-content-border: 2px solid lighten(var(--background), 2.5%);
  --non-content-border-hover: 2px solid lighten(var(--background), 5%);

  --fieldset-background: lighten(var(--background-secondary), 5%);
  --legend-color: linear-gradient(var(--color), var(--color-hover), var(--color));
}
</style>