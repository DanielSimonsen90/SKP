<template>
    <div class="project-container" v-if="projects && projects.length">
        <project  v-for="(project, i) in projects" :key="i"
            :project="project"
            :collabText="collabText"
            :linkTexts="linkTexts"
            :languageValue="languageValue"
            :language="language"

            @navigate="onNavigate"
        />
    </div>
    <div class="no-projects" v-else>
        <h3>{{ language.get('noProjects') }}</h3>
    </div>
</template>

<script>
import Project from './Project.vue';

/**@props: { projects: Array<Project>, noProjects: string }*/
export default {
    name: 'projects',
    components: { Project },
    props: { 
        projects: Array, 
        noProjects: String, 
        languageValue: String, 
        language: Map 
    },
    computed: {
        collabText(_this) {
            return _this.language.get('collabText');
        },
        linkTexts(_this) {
            return _this.language.get('linkTexts');
        }
    },
    methods: {
        onNavigate(link) {
            this.$emit('navigate', link);
        }
    }
}
</script>

<style>

</style>