<template>
  <div id="projects">
    <projects :projects="filterProjects()" />
  </div>
</template>

<script>
import { Me } from 'models';
import Projects from './Projects.vue';

/**@props { me: Me, all: string, language: string, projectType: string }*/
export default {
    components: { Projects },
    props: { 
        me: Me, 
        all: String,
        language: String,
        projectType: String
    },
    methods: {
        projectFilter(project) {
            const { display } = project;
            const language = project.language == this.language || project.language == 'C#' && this.language?.toLowerCase() == 'csharp' || this.language == this.all || !this.language;
            const projectType = project.projectType == this.projectType || this.projectType == this.all || !this.projectType;

            const result = display && language && projectType;
            return result;
        },
        filterProjects() {
            return this.me.projects.filter(this.projectFilter).sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime())
        }
    }
}
</script>

<style>

</style>