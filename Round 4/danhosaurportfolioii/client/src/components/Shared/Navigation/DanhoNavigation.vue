<template>
    <nav>
        <ul class="links">
            <danho-navigation-link 
                v-for="(link, i) in links" :key="i"
                :link="link" :tooltip="getTitle(i, link)"
                @click="onLinkClicked"
            />
        </ul>
    </nav>
</template>

<script>
import DanhoNavigationLink from './DanhoNavigationLink.vue';

/**@props { links: Array<string>, titles?: Array<string> } 
 * @emits navigate(link: string)*/
export default {
    name: 'danho-navigation',
    components: { DanhoNavigationLink },
    props: {
        links: Array,
        titles: Array
    },
    methods: {
        /**@param {string} link*/
        onLinkClicked(link) {
            this.$emit('navigate', link);
        },
        getTitle(index, link) {
            console.log(this.titles, link, index);
            return this.titles?.[index] || link;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/mixins';

.links {
    @include margin-block(0, 0);
    display: inherit;
    padding: 0;
    min-width: fit-content;
}
</style>