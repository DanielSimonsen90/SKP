<template>
  <header>
    <logo :hovering="logoHover" @hover="onLogoHover" />
    <ul id="links">
      <li class="link-item" 
        v-for="(link, i) in links" :key="i"
        @click="onLinkClicked(link)"
      >{{ link }}</li>
    </ul>
  </header>
</template>

<script>
import Logo from './Logo.vue'

import { Me } from 'models'

/**@props { me: Me, links: Array<string> } 
 * @emits navigate(link: string)*/
export default {
  name: "danho-header",
  components: { Logo },
  props: {
    me: Me,
    links: Array,
  },
  data: () => ({
    logoHover: false
  }),
  methods: {
    /**@param {string} link*/
    onLinkClicked(link) {
      this.$emit('navigate', link);
    },
    onLogoHover(hovering) {
      this.logoHover = hovering;
    }
  }
}
</script>

<style defer>
  :root {
    --link-item-padding: .5%;
  }

  header {
    display: grid;
    position: static;
  }

  #logo-container {
    position: relative;
    grid-row: 1;
    display: inline-block;
    height: 25%;
    width: 25%;
  }
  
  #logo {
    position: relative;
    display: inline-block;
    height: max-content;
    width: max-content;
  }

  #links {
    display: inline-flex;

    padding-inline-start: 0%;
  }

  .link-item {
    display: inline-block;
    padding-left: var(--link-item-padding);
    padding-right: var(--link-item-padding);
  }
</style>