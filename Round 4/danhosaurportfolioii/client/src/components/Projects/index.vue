<template>
  <div id="projects">
    <projects :projects="projects" />
  </div>
</template>

<script>
import { Me } from 'models';
import { API } from '../../data';
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
    async created() {

    },
    asyncComputed: {
        async projects() {
            let arr = this.me.projects;
            // let arr = await API.getProjects();
            return arr.filter(this.projectFilter).sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime())
        }
    },
    data: () => ({
        projects: []
    }),
    methods: {
        projectFilter(project) {
            const { display } = project;
            const language = project.language == this.language || project.language == 'C#' && this.language?.toLowerCase() == 'csharp' || this.language == this.all || !this.language;
            const projectType = project.projectType == this.projectType || this.projectType == this.all || !this.projectType;

            const result = display && language && projectType;
            return result;
        },
    }
}
</script>

<style>

</style>