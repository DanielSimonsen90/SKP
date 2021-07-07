<template>
  <div id="projects">
    <projects :projects="projects" :languageValue="languageValue" :language="language"/>
  </div>
</template>

<script>
import { Me } from 'models';
import { API } from '../../data';
import Projects from './Projects.vue';

/**@props { me: Me, language: string, projectType: string }*/
export default {
    components: { Projects },
    props: { 
        me: Me, 
        language: Map,
        languageValue: String,
        projectLanguage: String,
        projectType: String,
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
            const all = this.language.get('all');
            const { display } = project;
            const language = project.language == this.projectLanguage || project.language == 'C#' && this.projectLanguage?.toLowerCase() == 'csharp' || this.projectLanguage == all || !this.projectLanguage;
            const projectType = project.projectType == this.projectType || this.projectType == all || !this.projectType;

            const result = display && language && projectType;
            return result;
        },
    }
}
</script>

<style>

</style>