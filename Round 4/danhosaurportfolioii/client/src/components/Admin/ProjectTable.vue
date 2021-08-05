<template>
  <div id="project-table">
      <project-table-row :project="titles" :language="language" :clickable="false"/>
      <project-table-row v-for="(project, i) in projects.sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime())" :key="i"
        :project="project" :language="language" :clickable="true" 
        @update="onProjectUpdate" @delete="onProjectDelete" @navigate="onNavigate"
      />
  </div>
</template>

<script>
import { ProjectCollection } from 'models'
import ProjectTableRow from './ProjectTableRow.vue';

/**@props { language: Map<string, string>, projects: ProjectCollection }
 * @emits update(project: Project)
 * @emits delete(project: Project)
 * @emits navigate(link: string)*/
export default {
    components: { ProjectTableRow },
    name: 'project-table',
    props: {
        language: Map,
        projects: ProjectCollection,
    },
    computed: {
        titles() {
            return Object.keys(this.projects[0]).map(prop => { return this.language.get(prop) });
        }
    },
    methods: {
        onProjectUpdate(project) { this.$emit('update', project); },
        onProjectDelete(project) { this.$emit('delete', project); },
        onNavigate(link) { this.$emit('navigate', link) }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/mixins';
@import '@/scss/variables';

#project-table {
    @extend %hoverable-border;
    @extend %hoverable-background;
    @extend %rounded;
    @extend %shadow-me;

    display: grid;
    position: absolute;
    @include height-width(80%, 90%);
    margin-bottom: 3%;
    overflow: auto;
    justify-self: center;
    left: 5%;
    padding: 5px;
    top: 10%;

    &:hover {
        background-color: darken($background-secondary, $theme-difference / 2.5);
        background-image: unset;
    }

    &.modal {
        top: 25%;
    }
}

</style>