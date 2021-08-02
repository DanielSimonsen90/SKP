<template>
  <img :src="`data:image/png;base64,${project.image}`" class="project-image" v-if="project">
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

<style>

</style>