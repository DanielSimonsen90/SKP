<template>
    <fieldset :id="id">
        <legend>{{ title }}</legend>
        <content class="article-content">
            <p class="article-sentence" v-for="(sentence, i) in content" :key="i" :id="`${id}-${i}`">{{ sentence }}</p>

            <br />
            <p class="article-sentence" :id="`${id}-projects`">{{ projectString }}</p>
            <danho-navigation id="favorite-projects"
                :links="projects" :titles="projectTitles"
                @navigate="onNavigate"
            />
        </content>
    </fieldset>
</template>

<script>
import DanhoNavigation from '../Shared/Navigation/DanhoNavigation.vue'

/**@props { data: { title: string, content: Array<string>, projectString: string, projects: Array<string> } }*/
export default {
  components: { DanhoNavigation },
    name: 'who-dis',
    props: {
        data: {
            title: String,
            content: Array,
            projectString: String,
            projects: Array,
        },
        language: Map
    },
    data: () => ({
        id: 'who-dis'
    }),
    computed: {
        title: (_this) => _this.data.title,
        content: (_this) => _this.data.content,
        projectString: (_this) => _this.data.projectString,
        projects: (_this) => _this.data.projects,
        projectTitles: (_this) => _this.projects.map(p => _this.language.get('whoDisSeeMyProject')(p)),
    },
    methods: {
        onNavigate(link) {
            this.$router.push(`${this.language.get('projects')}/?${this.language.get('project')?.toLowerCase()}=${link}`)
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/mixins';
@import '@/scss/partials';

#who-dis {
    // width: 50%;
    grid-column: 1;
    grid-row: 1;
}

p:not(#occupation):not(#who-dis-projects) .article-content {
    @include margin-block(5px, 0);
}

#who-dis-projects, #favorite-projects {
    display: inline;
    justify-content: space-around;
}

#favorite-projects .link-item {
    @extend %click-me;
}
</style>