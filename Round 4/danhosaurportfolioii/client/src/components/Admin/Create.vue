<template>
  <div id="project-create" class="modal-content">
    <fieldset id="project-create-content">
      <legend>{{ language.get('createProject') }}</legend>

      <fieldset id="project-create-required">
            <legend>{{ language.get('projectInfo') }}</legend>
            <label id="project-create-required-1">
                <p>{{ language.get('name') }}</p>
                <input id="project-name" type="text" required placeholder="My super awesome project">

                <label id="project-create-display">
                    <p>{{ language.get('display') }}</p>
                    <input id="project-display" type="checkbox" required>
                </label>
            </label>

            <div id="project-create-required-2" class="split-3">
                <label class="project-filters split-item" :id="`project-create-filter-${type}`" v-for="({ type, name }, i) in projectFilters" :key="i">
                    <p>{{ language.get(name || type) }}</p>
                    <input :id="`project-${type}`" type="text" :list="`filter-data-${type}`" required>
                    <datalist :id="`filter-data-${type}`">
                        <option v-for="(item, j) in getProjectFilterOptions(type)" :key="j">{{ item }}</option>
                    </datalist>
                </label>
                <label id="project-create-createdAt">
                    <p>{{ language.get('createdAt') }}</p>
                    <input id="project-createdAt" type="date" required :value="currentDate">
                </label>
            </div>

            <div id="project-create-required-3" class="split-2">
                <label class="project-description split-item" :id="`project-create-description-${lang}`" v-for="(lang, i) in supportedLanguages" :key="i">
                    <p>{{ language.get(`description-${lang}`) }}</p>
                    <!-- <input type="text" required :placeholder="language.get('languagePlaceholder')">  -->
                    <textarea :id="`project-description-${lang}`" :name="lang" cols="30" rows="10" :placeholder="languages.get(lang).get('languagePlaceholder')"></textarea>
                </label>
            </div>
      </fieldset>
      
      <fieldset id="project-create-optional">
        <legend>{{ language.get('projectOptional') }}</legend>

        <div class="project-create-option">
            <label id="project-create-baseLink">
                <p>{{ language.get('baseLink') }}</p>
                <input id="project-baseLink" type="text" placeholder="/Education/Hovedforløb 69/...">
            </label>
            <label id="project-create-hasLink">
                <p>{{ language.get('hasLink') }}</p>
                <input id="project-hasLink" type="checkbox" checked>
            </label>
            <label id="project-create-spareTime">
                <p>{{ language.get('spareTimeTitle') }}</p>
                <input id="project-spareTime" type="checkbox">
            </label>
        </div>

        <fieldset id="project-create-github" class="project-create-option">
            <legend>{{ language.get('collabInfo') }}</legend>
            <label id="project-create-github-author">
                <p>{{ language.get('collabName') }}</p>
                <input id="project-collab-github" type="text" placeholder="github.com/..."> 
            </label>
            <label id="project-create-github-repo">
                <p>{{ language.get('collabRepo') }}</p>
                <input id="project-collab-repo" type="text" placeholder="github.com/${collabName}/...">
            </label>
        </fieldset>
      </fieldset>

      <button id="project-create-submit" @click="onProjectSubmit" type="submit">Create Project</button>
    </fieldset>
  </div>
</template>

<script>
import { languages } from '../../data';
import { Me, Project, DanhoDate } from 'models';


/**@props { language: Map<string, string> }
 * @emits create(project: Project)*/
export default {
    name: 'project-create',
    props: {
        language: Map,
        me: Me
    },
    data: () => ({
        projectFilters: [
            { name: 'languageLabel', type: 'language' },
            { type: 'projectType' },
        ],
        languages
    }),
    computed: {
        supportedLanguages() {
            return languages.keys();
        },
        currentDate() {
            const date = new Date();
            return [date.getFullYear(), date.getMonth() + 1, date.getDate()].join('-')
        }
    },
    methods: {
        /**@param {'language' | 'projectType'} type*/
        getProjectFilterOptions(type) {
            return this.me.projects.reduce((result, p) => {
                if (!result.includes(p[type]))
                    result.push(p[type]);
                return result;
            }, []).sort();
        },
        onProjectSubmit() {
            try { var p = this.createProject(); } 
            catch (err) { alert(err); }
            
            this.$emit('create', p);
        },
        createProject() {
            const get = (prop) => document.getElementById(`project-${prop}`);

            const description = {
                Dansk: get('description-Dansk').value.split('\n'),
                English: get('description-English').value.split('\n'),
            };

            const collabValues = {
                github: get('collab-github').value,
                repo: get('collab-repo').value
            };
            const collab = Object.keys(collabValues).map(p => collabValues[p] !== "").length ? collabValues : null;

            const requiredObj = { 
                name: get('name').value, 
                display: get('display').checked, 
                language: get('language').value, 
                projectType: get('projectType').value, 
                createdAt: get('createdAt').value, 
                
                descriptionDansk: description.Dansk[0], 
                descriptionEnglish: description.English[0] 
            };
            const required = new Map(Object.keys(requiredObj).map(prop => [prop, requiredObj[prop]]));

            let resultBuilder = {};
            for (const [key, value] of required) {
                if (value === "" || value == undefined || value == null) {
                    throw `${key} must not be null!`;
                }
                resultBuilder[key] = value;
            }

            const { name } = resultBuilder;
            const result = new Project(name, { ...resultBuilder, 
                hasLink: get('hasLink').checked, 
                baseLink: get('baseLink').value, 
                spareTime: get('spareTime').checked, 
                collab
            });

            return result;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

#project-create {
    position: fixed;
    margin: 0 auto;
    z-index: 4;
    
    @include max-height-width(90%, 50%);
    @include height-width(100%, 50%);

    & > * { position: absolute; height: inherit; }
    &-required, &-optional { top: -2em; position: relative; height: 100%; }

    &-content {
        display: grid;
        grid-template-columns: 60% 39%;
        grid-template-rows: 5% 85% 5%;

        legend {
            width: max-content;
            grid-column: 2;
            grid-row: 1;
        }
    }

    &-required {
        grid-row: 2;
        grid-column: 1;

        & > * { position: relative; }
        &-1 input { font-size: 24px; }
        &-3 { 
            height: 62.5%;

            input { height: 100%; }
            textarea { max-height: 100%; height: 80%; }
            p { text-align: center; }

            & > * { position: relative; }
        }
    }
    &-optional {
        grid-row: 2;
        grid-column: 2;

        & * { display: inline; }
    }
    &-submit {
        grid-row: 3;
        grid-column: 1 / 3;
        height: 150%;
    }
}

#project-create-required-1, 
.project-create-option,
.split-item {
    display: inline-block;
}

#project-create-display {
    display: inline;
    position: relative;

    & > * { display: inherit; }
}

.project-description {
    height: 100%;
}

.project-create-option {
    margin: 4%;
    
    label  {
        input[type=text] {
            width: 90%;
            text-align: center;
        }
        input[type=checkbox] {
            margin-top: 7.5%;
        }
    }
}

label {
    margin: 2%;

    & > p { font-weight: bold; }
}

button {
    @extend %hoverable-background;
    @extend %hoverable-color;
    @extend %shadow-me;
    @extend %clickable;

    background: $background-secondary;
    margin: 1%;
}

@mixin split($split-item-division) {
    display: flex;
    flex-direction: row;

    .split-item {
        max-width: 100% / $split-item-division;
        input, textarea { width: 100%; }
    }
}

.split-2 { @include split(2); }
.split-3 { @include split(3); }
</style>