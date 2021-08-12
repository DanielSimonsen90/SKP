<template>
  <header class="header">
    <logo title="Go home, you're drunk"
      :hovering="logoHover" :width="100" 
      @click="navigateTo('Home')"
      @hover="onLogoHover" 
    />

    <project-filter :title="filterTitle" :visibility="filterVisibility"
      :projectLanguage="projectLanguage" :projectType="projectType" :language="language"
      :me="me" 
      @project-filter-change="onFilterChange"
    />

    <danho-navigation id="header-navigation"
      :links="links"
      @navigate="navigateTo"
    />
  </header>
</template>

<script>
import Logo from './Logo.vue'
import DanhoNavigation from './Navigation/DanhoNavigation.vue';
import ProjectFilter from '../Projects/ProjectFilter.vue';

import { Me } from 'models'

import { projectsRoutes } from '../../data';

/**@props { me: Me, links: Array<string>, filterTitle: string, all: String, language: String, projectType: string } 
 * @emits navigate(link: string)
 * @emits project-filter-change(type, value)*/
export default {
  name: "danho-header",
  components: { Logo, DanhoNavigation, ProjectFilter },
  props: {
    me: Me,
    links: Array,

    filterTitle: String,
    all: String,
    language: Map,
    projectLanguage: String,
    projectType: String
  },
  data: () => ({ logoHover: false }),
  computed: {
    filterVisibility() {
      return projectsRoutes.reduce((result, { path }) => {
        result.push(path.toLowerCase(), `${path.toLowerCase()}/`);
        return result;
      }, []).includes(this.$route.path.toLowerCase()) ? 'visible' : 'hidden';
    }
  },
  methods: {
    /**@param {string} link*/
    navigateTo(link) {
      this.$emit('navigate', link);
    },
    onLogoHover(hovering) {
      this.logoHover = hovering;
    },
    onFilterChange(type, value) {
      this.$emit('project-filter-change', type, value);
    }
  }
}
</script>

<style lang="scss">
  @import '@/scss/variables';
  @import '@/scss/partials';

  .header {
    @extend %non-content;
    justify-content: space-between;
    align-items: center;

    height: 9%;
    max-height: 60px;

    &:hover {
      color: lighten($color-hover, 10%);

      #logo-container #logo { opacity: 0.6; }
    }

    #logo-container #logo {
      opacity: 0.2;

      &:hover { opacity: 1; }
    }
  }
  
  #header-navigation {
    width: 27.5%;
    height: 90%;

    .link-item {
      @extend %hoverable-background;

      font-size: 27.5px;
      padding: $link-item-padding-top-bottom $link-item-margin + 2%;

      &:hover { 
        background-color: lighten($background-hover, 3%);
      }
    }
  }
</style>