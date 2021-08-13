<template>
  <div class="project" :name="project.name">
      <h1>[{{ project.name }}] • {{ project.createdAt.toString() }} • {{ project.language }} • {{ project.projectType }}</h1>
      <div class="project-info">
          <div class="project-text">
            <div class="project-description" v-for="(sentence, i) in project.description[languageValue]" :key="i">
              <a v-if="sentence && sentence.startsWith('http')" class="link-item" :href="sentence">{{ language.get('whoDisSeeMyProject')(project.name) }}</a>
              <p v-else-if="sentence">{{ sentence }}</p>
              <br v-else />
            </div>
            <p class="project-collab" v-if="project.collab != null && project.collab != undefined">{{ collabText }} {{ project.collab.github }}</p>
            <p class="project-link" v-if="project.link && project.link != 'No link'">{{ linkTexts[0] }} <b>{{ project.name }}</b> {{ linkTexts[1] }}</p>
          </div>
          <img class="project-image" :src="`data:image/png;base64,${project.image}`" v-if="fileExists" />
          <p v-else>{{ language.get('noImage') }}<br /><b>{{ project.name }}</b>.</p>
      </div>
  </div>
</template>

<script>
import { Project } from 'danhosaurportfolio-models';

/**@props { project: Project, collabText: string, linkTexts: Array<string>, language: Map<string, string> }
 * @emits navigate(link: string)*/
export default {
    name: 'project',
    props: {
        project: Project,
        collabText: String,
        linkTexts: Array,
        languageValue: String,
        language: Map
    },
    mounted() {
        const projectImage = (() => {
            const projectInfo = this.projectElement.children[1];
            for (let i = 0; i < projectInfo.children.length; i++) {
                const child = projectInfo.children[i];
                
                if (child.tagName == 'IMG') return child;
            }
            return null;
        })();

        const { onClicked } = this;

        this.projectElement.onclick = (e) => onClicked(e, 'project');
        if (projectImage) projectImage.onclick = (e) => onClicked(e, 'image');
    },
    computed: {
        fileExists() {
            return this.project.image != null;
        },
        projectElement() {
            return document.getElementsByName(this.project.name)[0]
        } 
    },
    methods: {
        onClicked(e, target) {
            if (target == 'image') {
                e.stopPropagation();
                console.log({ route: this.$route })
                return this.$emit('navigate', `${this.$route.path.substring(1)}/${this.language.get('images')}/?${this.language.get('image')?.toLowerCase()}=${this.project.name}`);
            }

            if (!this.project.link) return;

            window.location.href = this.project.link;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/variables';
@import '@/scss/mixins';

$max-height: 600px;

.project {
    @extend %shadow-me;
    @extend %clickable;
    @extend %rounded;

    transition: 
        background-color $transition-hover, 
        color $transition-hover,
        border-color $transition-hover;
    display: block;
    width: 75%;
    height: 25%;
    max-height: $max-height;

    margin: 20px auto;
    padding: 10px;
    
    text-align: left;

    &:hover {
        background-color: lighten($background-secondary, $theme-difference / 4);
        color: lighten($color, $theme-difference);
        border-color: $theme-secondary;
    }

    h1 {
        @include margin-block(.34rem, .67rem);
    }
}

.project-info {
    @extend %rounded;

    display: flex;
    flex-direction: row;
    justify-content: space-between;
    background: $background-secondary;
    border: 2px solid $theme-secondary;
    width: 100%;
    height: min-content;
    max-height: $max-height - 100px;
    position: relative;
    
    > * { 
        margin-left: 10px; 
        display: inline-block;
        max-height: inherit;
    }

    .project-text + p {
        width: 49%;
        text-align: center;
    }
}
.project-text {
    position: relative;
    vertical-align: top;
    height: $max-height;
    font-size: 18px;
    overflow: auto;
}
.project-link {
    @extend %click-me;
    transition: font-weight $transition-hover;
    position: absolute;
    display: inline-block;
    bottom: 0;
    text-align: center;
    width: 100%;

    b {
        transition: font-size $transition-hover;
    }
    &:hover b {
        font-size: 22px;
    }
}
.project-image, .project-text {
    @extend %rounded;
    width: 49%;
}
</style>