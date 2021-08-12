<template>
  <div id="projects">
    <projects :projects="projects" :languageValue="languageValue" :language="language" @navigate="onNavigate" v-if="projects"/>
    <div class="no-projects" v-else>
        <h3>{{ loadingProjects }}</h3>
    </div>
  </div>
</template>

<script>
import { Me, ProjectCollection } from 'models';
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
        projects: ProjectCollection
    },
    created() {
        this.loadingProjects = this.language.get('loadingProjects');
        if (!this.interval) {
            this.interval = setInterval(() => {
                if (this.loadingProjects.endsWith('...')) {
                    this.loadingProjects = this.language.get('loadingProjects');
                }
                else this.loadingProjects += '.';
            }, 1000);
        }    
    },
    asyncComputed: {
        async projects() {
            let arr = this.me.projects || await API.getProjects();
            const result = arr.filter(this.projectFilter).sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime());
            clearInterval(this.interval);

            if (this.$route.query) {
                setTimeout(() => {
                    const projectContainer = document.getElementsByClassName('project-container')[0];
                    if (!projectContainer) return;

                    const scrollToProject = projectContainer.children.namedItem(this.$route.query[this.language.get('project')?.toLowerCase()]);
                    
                    if (scrollToProject) {
                        scrollToProject.scrollIntoView({ behavior: 'smooth' });
                    }
                }, 500);
            }

            return result;
        }
    },
    data: () => ({
        loadingProjects: null,
        interval: null
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
        onNavigate(link) {
            this.$emit('navigate', link);
        }
    }
}
</script>

<style>

</style>