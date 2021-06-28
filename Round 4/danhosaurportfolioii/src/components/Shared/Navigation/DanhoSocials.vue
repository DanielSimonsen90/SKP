<template>
  <ul>
      <li v-for="(link, i) in links" :key="i" class="link-item">
          <img class="socials-icon" :src="link.image" :alt="link.name" :title="link.name" v-if="displayIcons">
          <a @click="link.click" :title="link.name">{{ link.name }}</a>
      </li>
  </ul>
</template>

<script>
import { Me } from 'models'

/**@props: { me: Me }*/
export default {
    name: 'danho-socials',
    props: {
        me: Me,
        displayIcons: Boolean
    },
    computed: {
        links: (_this) => Object.keys(_this.me.contact).map((prop) => {

            const name = prop.substring(0, 1).toUpperCase() + prop.substring(1);
            const value = _this.me.contact[prop];
            const click = _this[`on${name}Click`] && (() => _this[`on${name}Click`](value)) || (() => { _this.onNoCallback(prop); });
            const image = `${window.location.origin}/socials/${prop}.png`;
            return { prop, name, value, click, image };
        })
    },
    methods: {
        /**@param {string} prop*/
        onNoCallback(prop) { alert(`The callback for ${prop} was not recognized... Sorry!`); },

        /**@param {string} link*/
        linkRedirect(link) { window.location.href = link; },
        onGithubClick(value) { this.linkRedirect(`https://github.com/${value}`); },
        onEmailClick(value) { this.linkRedirect(`mailto:${value}`); },
        onPhoneClick(value) { alert(value); },
    }
}
</script>

<style lang="scss">
.socials-icon {
    width: 10%;
    margin-right: 2%;
}
</style>