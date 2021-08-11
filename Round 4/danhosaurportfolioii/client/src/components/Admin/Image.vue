<template>
  <img :src="`data:image/png;base64,${project.image}`" id="display-image" class="project-image" v-if="project">
</template>

<script>
import { Me } from 'models';
import { API } from '../../data'; 

/**@props { me: Me, language: Map<string, string> } */
export default {
    props: {
        me: Me,
        language: Map
    },
    asyncComputed: {
        async project() {
            const projects = this.me?.projects || await API.getProjects();
            return projects.find(({ name }) => this.$route.query[this.language.get('image')?.toLowerCase()] == name);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/mixins';

#display-image {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);

    @include height-width(75%, 75%);
    @include max-height-width(inherit, inherit);
}
</style>