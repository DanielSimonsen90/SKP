<template>
  <div class="project-table-row" :name="project.name">
      <div class="project-table-cell" v-for="([prop, v], i) in data" :key="i" :name="prop" :value="v" @click="onCellClick(data[i])">
          <p v-if="v != null && !['description', 'image', 'link', 'collab'].includes(prop)">{{ v }}</p>
          <a v-else-if="prop == 'link' && v && v != 'No link'" class="click-me" :href="v" target="_blank">[link]</a>
          <p v-else-if="v && !['image', 'collab'].includes(prop)" class="click-me">[{{ language.get(prop) }}]</p>
          <img v-else-if="prop == 'image' && v" class="project-image" :src="`data:image/png;base64,${project.image}`"/>
          <p v-else-if="prop == 'collab' && v" class="collab-cell click-me" @click="toGithub(v.githubLink)"><b>{{ v.github }}</b></p>
          <p v-else value="NA">N/A</p>
      </div>
      <div class="project-table-cell" name="update">
          <button @click="onUpdateClick" v-if="clickable">{{ language.get('update') }}</button>
          <p v-else>{{ language.get('update') }}</p>
      </div>
      <div class="project-table-cell" name="delete">
          <button @click="onDeleteClick" v-if="clickable">{{ language.get('delete') }}</button>
          <p v-else>{{ language.get('delete') }}</p>
      </div>
  </div>
</template>

<script>
import { Project } from 'models';

/**@props { language: Map<string ,string>, project: Project, clickable: boolean }
 * @emits delete(project: Project)
 * @emits update(project: Project)
 * @emits navigate(link: string)*/
export default {
    name: 'project-table-row',
    props: {
        language: Map,
        project: Project,
        clickable: Boolean
    },
    mounted() {
        let element = document.querySelector(`.project-table-row[name="${this.project.name}"]`);
        if (!element) return;
        
        if (this.clickable) {
            for (let i = 0; i < element.children.length; i++) {
                element.children[i].classList.add('clickable');
            }
        }
        else {
            element.style.position = 'sticky';
            console.log(element);
        }
    },
    computed: {
        data() {
            return Object.keys(this.project).map(prop => [prop, this.project[prop]]);
        }
    },
    methods: {
        onCellClick([prop, value]) {
            if (!this.clickable || ['link', 'collab'].includes(prop)) return;

            if (prop == 'description') {
                return alert(Object.keys(value).reduce((msg, prop) => msg += `${prop}:\n${value[prop].join('\n')}\n\n`, ''));
            }
            else if (prop == 'image' && value) {
                return this.$emit('navigate', `Admin/${this.language.get('images')}/?${this.language.get('image')?.toLowerCase()}=${this.project.name}`);
            }

            alert(`${prop}\n\n${[null, undefined].includes(value) ? `${prop} is ${value}.` : value}`);
        },
        toGithub(link) {
            window.location.href = link;
        },
        onUpdateClick() {
            this.$emit('update', this.project);
        },
        onDeleteClick() {
            this.$emit('delete', this.project);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/mixins';
@import '@/scss/partials';
@import '@/scss/variables';

$table-margin: .25%;

.clickable { @extend %clickable; }
.click-me { @extend %click-me; }

.project-table-row {
    &[value] {
        position: relative;
    }

    display: table-row;
    margin: $table-margin 0;

    &:hover .project-table-cell {
        background-color: lighten($background-secondary, $theme-difference / 3);
    }
}
.project-table-cell {
    @extend %hoverable-border;
    @extend %shadow-me;
    @extend %rounded;

    $height: 45px;
    $width: 120px;
    @include height-width($height, $width);
    background-color: $background-secondary;
    display: table-cell;
    overflow: hidden;
    padding: $height / 8;
    position: relative;
    vertical-align: middle;

    &:hover {
        background-color: lighten($background-secondary, $theme-difference) !important;
    }

    & > * {
        display: inline;
        position: absolute;

        @include height-width(auto, inherit);
        @include max-height-width($height, $width);
        @include tblr(50%, initial, 50%, initial);
        transform: translate(-50%, -50%);
        word-wrap: break-word;
        overflow-y: auto;
    }
    
    p {
        @include margin-block(0, 0);
        padding: 5%;
    }

    button {
        width: max-content;
        @include max-height-width(100%, max-content);
        font-size: 18px;
        padding: 5% 10%;
    }

    .project-image {
        @include height-width($height, $width);
        border-radius: 5px;
    }

    .collab-cell b {
        padding: inherit;
        font-size: 12px;

        &:hover {
            font-size: 16px;
        }
    }

    &[name=display] > p, &[name=spareTime] > p { color: red; }
    & > p[value=NA] { color: inherit; }
    &[value=true] > p { color: lime; }
}
</style>