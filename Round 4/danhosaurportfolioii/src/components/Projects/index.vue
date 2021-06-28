<template>
  <div id="projects">
    <projects :projects="filterProjects()" />
  </div>
</template>

<script>
import { Me } from 'models';
import Projects from './Projects.vue';

export default {
    components: { Projects },
    props: { me: Me },
    created() {
        const all = 'Alle';

        this.all = all;
        this.language = "";
        this.projectType = "";
    },
    data: () => ({
        all: null,
        language: null,
        projectType: null
    }),
    methods: {
        projectFilter(project) {
            const { display } = project;
            const language = project.language == this.language || this.language == this.all || !this.language;
            const projectType = project.projectType == this.projectType || this.projectType == this.all || !this.projectType;

            const result = display && language && projectType;
            return result;
        },
        filterProjects() {
            return this.me.projects.filter(this.projectFilter).sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime())
        },
        onChange(type, newValue) {
            this[type] = newValue;
            console.log(this[type])
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';

#project-filter-container {
    @extend %shadow-me;
    
    position: fixed;
    width: 10px;
    left: 0;
}
</style>