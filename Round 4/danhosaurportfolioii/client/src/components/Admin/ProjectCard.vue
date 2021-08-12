<template>
  <div class="project-card" :name="project.name">
      <header>
          <div class="basic-info">
            <h1 class="project-name" :title="project.name">{{ project.name }}</h1>
            <div class="project-language-createdAt">
                <h5>{{ project.language }} • {{ project.projectType }}</h5>
                <h5 class="project-createdAt">{{ project.createdAt.toString() }}</h5>
            </div>
          </div>
          <div class="checkboxes">
              <p class="project-id">{{ displayButtons ? project._id : project.index + 1 }}</p>
              <label v-for="([title, value], i) in labelData" :key="i">
                  <p :value="value" :index="i">{{ title }}</p>
                  <input type="checkbox" :checked="value" disabled>
              </label>
          </div>
      </header>
      <content>
          <div class="description-container project-description" v-for="(sentence, i) in project.description[languageValue]" :key="i">
            <p>{{ sentence }}</p>
          </div>
          <p v-if="project.collab != null"><b>Collab with:</b> {{ project.collab.github }}</p>
          <a v-if="project.link" class="project-link" target="_blank" :href="project.link">{{ language.get('project') }} Link</a>
      </content>
      <div id="project-image-container">
        <img v-if="project.image" class="project-image" @click="onImageClicked" :src="`data:image/png;base64,${project.image}`">
        <p v-else>{{ language.get('noImage') }} <br /> <b>{{ project.name }}</b>.</p>
      </div>
      <footer v-if="displayButtons">
          <button type="update" @click="onUpdateClicked">{{ language.get('update') }}</button>
          <button type="delete" @click="onDeleteClicked">{{ language.get('delete') }}</button>
      </footer>
  </div>
</template>

<script>
import { Project } from 'danhosaurportfolio-models';

/**@props { project: Proejct, language: Map<string, string>, languageValue: string }
 * @emits navigate(link: string)
 * @emits update(project: Project)
 * @emits delete(project: Project)*/
export default {
    name: 'project-card',
    props: {
        project: Project,
        language: Map,
        languageValue: String,
        displayButtons: Boolean
    },
    data: (_this) => {
        const { display, spareTime } = _this.project;
        const labelData = [
            [display ? _this.language.get('showing') : _this.language.get('hiding'), display],
            [_this.language.get('spareTime'), spareTime]
        ].filter(([title], i) => _this.displayButtons || i != 0)

        return {
            labelData
        }
    },
    methods: {
        onImageClicked() {
            this.$emit('navigate', `Admin/${this.language.get('images')}/?${this.language.get('image')?.toLowerCase()}=${this.project.name}`);
        },
        onUpdateClicked() {
            this.$emit('update', this.project);
        },
        onDeleteClicked() {
            this.$emit('delete', this.project);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

@mixin heights($height) {
    min-height: $height;
    height: $height;
    max-height: $height;
}

.project-card {
    @extend %hoverable-border;
    @extend %hoverable-background;
    @extend %rounded;
    @extend %shadow-me;

    @include height-width(375px, 21.1%);

    display: flex;
    flex-direction: column;
    overflow: hidden;
    padding: 1% 1.5%;
    margin: .25%;

    > * {
        margin: 1%;
    }

    header {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: space-evenly;
        position: relative;
        width: 110%;
        left: -6%;
    }
    content {
        @extend %hoverable-border;
        @extend %rounded;

        display: block;
        background-color: $fieldset-background;
        border-color: darken($background-secondary, $theme-difference);
        
        @include heights(25%);

        overflow-y: auto;
        overflow-x: hidden;
        word-wrap: break-word;
        text-align: left;
        padding: 2% 2.5%;

        &:hover {
            border-color: darken($background, $theme-difference / 4);
        }


        p {
            @include margin-block(1%, 1%);
        }

        .project-link {
            margin-top: 2%;
            position: relative;
            text-align: left;
        }

        .description-container.project-description {
            margin-bottom: 5%;
        }
    }
    #project-image-container {
        @extend %hoverable-border;
        @extend %rounded;
        @include heights(40%);

        background-color: darken($background, $theme-difference / 4);
        
        img.project-image {
            @include max-height-width(100%, 500%);
            border-color: $background-hoverable;

            position: relative;
            display: block;
            width: 100%;
            height: 100%;
        }
        p {
            position: relative;
            top: 20%;
            height: 50%;
        }

        &:not(footer) {
            height: 50%;
            max-height: 50%; 
        }  
    }
    footer {
        display: flex;
        flex-direction: row;
        align-content: flex-end;
        justify-content: space-between;
        align-items: stretch;

        button {
            width: 100%;

            &[type=update] {
                color: rgb(255, 254, 191)
            }
            &[type=delete] {
                color: rgb(255, 155, 155)
            }
        }
    }
}

.basic-info {
    text-align: left;
    min-width: 215px;
    max-width: 215px;
    padding: 1%;
    display: flex;
    flex-direction: column;

    h1, h5 {
        @include margin-block(0, 0);
    }

    h1 {
        font-size: 24px;
        word-wrap: initial;
        word-break: break-all;
        overflow: hidden auto;
        margin-bottom: 3%;
        max-height: 32px;
        width: 100%;
    }
    h5 {
        display: inline-block;
        height: 20px;
        position: relative;
        width: fit-content;

        &.project-createdAt {
            float: right;
            margin-left: 2%;
        }
    }

    .project-language-createdAt {
        display: flex;
        flex-direction: row;
        width: 100%;
    }
}
.checkboxes {
    position: relative;
    width: 52%;
    top: -10%;
    text-align: right;

    label {
        display: flex;
        flex-direction: row;
        justify-content: flex-end;
        width: 100%;

        p[index="0"] {
            color: rgb(255, 91, 91);

            &[value=true] {
                color: rgb(159, 255, 159);
            }
        }
        input {
            margin-right: 0;
            margin-bottom: 0;
        }
    }
    .project-id {
        position: relative;
        display: block;
    }
    p {
        display: inline;
        @include margin-block(0, 0);
    }
}
</style>