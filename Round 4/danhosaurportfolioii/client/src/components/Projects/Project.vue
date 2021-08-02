<template>
  <div class="project" :name="`${project.name}`" @click="toRepo">
      <h1>[{{ project.name }}] • {{ project.createdAt.toString() }} • {{ project.language }} • {{ project.projectType }}</h1>
      <div class="project-info">
          <div class="project-text">
            <div class="project-description" v-for="(sentence, i) in project.description[languageValue]" :key="i">
              <p v-if="sentence">{{ sentence }}</p>
              <br v-else />
            </div>
            <p class="project-collab" v-if="project.collab != null && project.collab != undefined">{{ collabText }} {{ project.collab.github }}</p>
            <p class="project-link" v-if="project.link" @click="toRepo">{{ linkTexts[0] }} {{ project.name }} {{ linkTexts[1] }}</p>
          </div>
          <img class="project-image" :src="`data:image/png;base64,${project.image}`" v-if="fileExists" />
          <p v-else>Der er intet billede til {{ project.name }}.</p>
      </div>
  </div>
</template>

<script>
import { Project } from 'models';

/**@props { project: Project, collabText: string, linkTexts: Array<string> }*/
export default {
    name: 'project',
    props: {
        project: Project,
        collabText: String,
        linkTexts: Array,
        languageValue: String
    },
    computed: {
        fileExists(_this) {
            return this.project.image != null;
        }
    },
    methods: {
        toRepo() {
            window.location.href = this.project.link;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/variables';
@import '@/scss/mixins';

.project {
    @extend %shadow-me;
    @extend %clickable;
    @extend %hoverable;
    @extend %rounded;

    display: block;
    width: 75%;
    height: 25%;

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

    background: $background-secondary;
    border: 2px solid $theme-secondary;
    width: 100%;
    height: min-content;
    
    > * { margin-left: 10px; display: inline-block; }

    .project-description { grid-column: 1; grid-row: 1; }
    .project-collab { grid-column: 1; grid-row: 2; }
    .project-link { grid-column: 1; grid-row: 3; }
    .project-image { grid-column: 2; grid-row: 1 / 3; }
}
.project-text {
    position: relative;
    vertical-align: top;
    height: 100vh;
    font-size: 18px;
}
.project-link {
    @extend %click-me;
    position: relative;
    bottom: 0;
    display: inline-block;
    vertical-align: bottom;
}
.project-image, .project-text {
    @extend %rounded;

    width: 49%;
    height: 25%;
}
</style>