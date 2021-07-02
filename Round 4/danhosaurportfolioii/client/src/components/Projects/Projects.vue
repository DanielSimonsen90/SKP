<template>
    <div class="project-container" v-if="projects && projects.length">
        <project  v-for="(project, i) in projects" :key="i"
            :project="project"
            :collabText="collabText"
            :linkTexts="linkTexts"
        />
    </div>
    <div class="no-projects" v-else>
        <h3>{{ noProjects }}</h3>
    </div>
</template>

<script>
import Project from './Project.vue';

/**@props: { projects: Array<Project>, noProjects: string }*/
export default {
    name: 'projects',
    components: { Project },
    props: { projects: Array, noProjects: String },
    data: () => ({
        collabText: 'Projektet er lavet sammen med',
        linkTexts: ['Se', 'på Github.'],
    }),
}
</script>

<style>

</style>