<template>
  <footer>
    <p id="copyright">© {{ new Date().getFullYear() }}</p>
    <p id="point-1">•</p>
    <p id="company-name">{{ me && me.name }}</p>
    <p id="point-2">•</p>
    <danho-navigation id="footer-navigation"
      :links="links"
      @navigate="onNavigate"
    />
    <p id="point-3">•</p>
    <danho-socials id="footer-socials"
      :me="me" :language="language"
    />
    <p id="point-4">•</p>
    <language-selector 
      :language="language" :languageValue="languageValue" 
      @change="onLanguageChanged" 
    />
  </footer>
</template>

<script>
import { Me } from 'models';
import DanhoNavigation from './Navigation/DanhoNavigation.vue';
import DanhoSocials from './Navigation/DanhoSocials.vue';
import LanguageSelector from './LanguageSelector.vue';

/**@props { me: Me, links: Array<string>, language: map<string, string>, languageValue: string } 
 * @emits navigate(link: string)
 * @emits language-change(value: string)*/
export default {
  name: 'danho-footer',
  components: { DanhoNavigation, DanhoSocials, LanguageSelector },
  props: {
    me: Me,
    links: Array,
    language: Map,
    languageValue: String
  },
  computed: {
    socials: () => Object.keys(this.me?.contact).reduce((map, prop) => map.set(prop, this.me.contact[prop]), new Map()),
    socialNames: () => Object.keys(this.me?.contact).map(prop => prop.substring(0, 1).toUpperCase() + prop.substring(1))
  },
  methods: {
    onNavigate(link) {
      this.$emit('navigate', link);
    },
    onSocialClick(link) {
      alert(this.me?.contact[link.toLowerCase()]);
    },
    onLanguageChanged(value) {
      this.$emit('language-change', value);
    }
  }
}
</script>

<style lang="scss">
@import '@/scss/mixins';
@import '@/scss/variables';
@import '@/scss/partials';

footer {
  @extend %non-content;

  grid-template-columns: 4% $footer-point-space 10% $footer-point-space 17.5% $footer-point-space 15% $footer-point-space 17.5%;
  
  //vertical horizontal
  padding: 1% 0;
  justify-content: center; 
  justify-items: center;


  & > * {
    @include margin-block(0, 0);  
    display: flex;
    justify-content: center;
    width: 100%;
    padding-inline-start: 0;
  }

  .link-item {
    box-shadow: unset;
    margin: 0 10px;
  }
}
</style>