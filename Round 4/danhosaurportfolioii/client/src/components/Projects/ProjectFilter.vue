<template>
  <fieldset id="projects-filter" :style="`visibility: ${visibility};`">
      <legend>{{ language.get('filterTitle') }}</legend>
      <content>
        <filter-label :type="'projectLanguage'" :inputValue="projectLanguage" :display="language.get('languageLabel')" :me="me" @change="onChange"/>
        <filter-label :type="'projectType'" :inputValue="projectType" :display="language.get('projectType')" :me="me" @change="onChange"/>
      </content>
  </fieldset>
</template>

<script>
import FilterLabel from './FilterLabel.vue';
import { Me } from 'models';

/**@props { title: string, visibility: string, language: string, projectType: string, me: Me }
 * @emits project-filter-change(type, value)*/
export default {
    name: 'project-filter',
    components: { FilterLabel },
    created() {
        const props = Object.keys(this.$route.query);
        if (!props.length) return;

        props.forEach(prop => this.onChange(prop, this.$route.query[prop]));
    },
    props: {
        visibility: String,

        language: Map,
        projectLanguage: String,
        projectType: String,

        me: Me
    },
    methods: {
        onChange(type, value) {
            this.$emit('project-filter-change', type, value);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';

#projects-filter {
    @extend %shadow-me;
    
    display: flex;
    justify-content: center;
    position: fixed;
    width: 35%;
    left: 50%;
    transform: translateX(-50%);

    label { display: inline; }
    legend { margin: 0 auto; }
}

</style>