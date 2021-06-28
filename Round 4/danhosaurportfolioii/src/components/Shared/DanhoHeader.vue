<template>
  <header>
    <logo title="Go home, you're drunk"
      :hovering="logoHover" :width="100" 
      @click="navigateTo('Home')"
      @hover="onLogoHover" 
    />

    <p id="test">no</p>

    <danho-navigation id="header-navigation"
      :links="links"
      @navigate="navigateTo"
    />
  </header>
</template>

<script>
import Logo from './Logo.vue'
import DanhoNavigation from './Navigation/DanhoNavigation.vue';

import { Me } from 'models'

/**@props { me: Me, links: Array<string> } 
 * @emits navigate(link: string)*/
export default {
  name: "danho-header",
  components: { Logo, DanhoNavigation },
  props: {
    me: Me,
    links: Array,
  },
  created() {
    if (['projects', 'projekter'].includes(document.location.pathname.toLowerCase()))
      document.querySelector('#test').value = "yes";
  },
  data: () => ({ logoHover: false }),
  methods: {
    /**@param {string} link*/
    navigateTo(link) {
      this.$emit('navigate', link);
    },
    onLogoHover(hovering) {
      this.logoHover = hovering;
    }
  }
}
</script>

<style lang="scss">
  @import '@/scss/variables';
  @import '@/scss/partials';

  header {
    @extend %non-content;

    grid-template-columns: 5% auto 25%;
    grid-template-rows: 100%;
    align-items: center;

    &:hover {
      color: lighten($color-hover, 10%);

      #logo-container #logo { opacity: 0.6; }
    }
    
    nav { grid-column: 3; }

    #logo-container { 
      grid-column: 1;

      #logo {
        opacity: 0.2;

        &:hover { opacity: 1; }
      }
    }
  }
  
  #header-navigation .link-item {
    @extend %hoverable-background;

    font-size: 25px;
    padding: $link-item-padding-top-bottom $link-item-margin + 2%;

    &:hover { 
      background-color: lighten($background-hover, 3%);
      padding: $link-item-padding-top-bottom + 1% $link-item-margin + 2%;
    }
  }
</style>