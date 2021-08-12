<template>
  <ul>
      <li v-for="(link, i) in links" :key="i" class="link-item">
          <img class="socials-icon" :src="link.image" :alt="link.name" :title="link.name" v-if="displayIcons">
          <a @click="link.click" :title="link.name">{{ language && language.has(link.name) ? language.get(link.name) : link.name }}</a>
      </li>
  </ul>
</template>

<script>
import { Me } from 'danhosaurportfolio-models'

/**@props: { me: Me }*/
export default {
    name: 'danho-socials',
    props: {
        me: Me,
        displayIcons: Boolean,
        language: Map
    },
    computed: {
        links: (_this) => _this.me ? Object.keys(_this.me.contact).map(prop => {
            const clickName = prop.substring(0, 1).toUpperCase() + prop.substring(1)
            const name = _this.language?.has(prop) ? _this.language.get(prop) : clickName;
            const value = _this.me.contact[prop];
            const click = _this[`on${clickName}Click`] && (() => _this[`on${clickName}Click`](value)) || (() => { _this.onNoCallback(prop); });
            const image = `${window.location.origin}/socials/${prop}.png`;
            return { prop, name, value, click, image, test: prop.substring(0, 1).toUpperCase() + prop.substring(1) };
        }) : [{ prop: null, name: null, value: null, click: () => alert("Hello there!"), image: null }]
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