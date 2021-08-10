<template>
  <div id="project-card-container">
    <project-card v-for="(project, i) in projects.sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime())" :key="i"
        :language="language" :languageValue="languageValue" :project="project"
        @navigate="onNavigate" @update="onUpdateRequest" @delete="onDelete"
  />
</div>
</template>

<script>
import { ProjectCollection } from 'models';
import ProjectCard from './ProjectCard.vue'

/**
 * @props {{ projects: ProjectCollection, language: Map<string, string>, languageValue: string }}
 * @emits navigate(link: string)
 * @emits update(project: Project)
 * @emits delete(project: Project)
 */
export default {
    name: 'project-card-container',
    components: { ProjectCard },
    props: {
        projects: ProjectCollection,
        language: Map,
        languageValue: String
    },
    methods: {
        onNavigate(link) {
            this.$emit('navigate', link);
        },
        onUpdateRequest(project) {
            this.$emit('update', project);
        },
        onDelete(project) {
            this.$emit('delete', project);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/mixins';
@import '@/scss/variables';

#project-card-container {
    @extend %hoverable-border;
    @extend %hoverable-background;
    @extend %rounded;
    @extend %shadow-me;

    @include height-width(95%, 90%);
    
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    justify-self: center;
    overflow: auto;

    position: absolute;
    left: 5%;
    top: 10%;
    margin-bottom: 3%;
    padding: 5px;
    background-color: darken($background-secondary, $theme-difference / 2);

    &:hover {
        background-color: darken($background-secondary, $theme-difference / 1.5);
        background-image: unset;
    }

    &.modal {
        top: 25%;
    }
}


</style>