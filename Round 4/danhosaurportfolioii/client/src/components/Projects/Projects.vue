<template>
    <div class="project-container">
        <project  v-for="(project, i) in projects" :key="i"
            :project="project"
            :collabText="collabText"
            :linkTexts="linkTexts"
        />
    </div>
</template>

<script>
import Project from './Project.vue';

/**@props: { projects: Array<Project> }*/
export default {
    name: 'projects',
    components: { Project },
    props: { projects: Array },
    data: () => ({
        collabText: 'Projektet er lavet sammen med',
        linkTexts: ['Se', 'på Github.'],
    }),
}
</script>

<style>

</style>