<template>
  <div id="project-create">
    <fieldset id="project-create-content" class="modal-content">
      <legend>{{ language.get('registerProject') }}</legend>

      <fieldset id="project-create-required">
            <legend>{{ language.get('projectInfo') }}</legend>
            <label id="project-create-required-1">
                <p>{{ language.get('name') }}</p>
                <input id="project-name" type="text" required :placeholder="language.get('projectNamePlaceholder')">

                <label id="project-create-display">
                    <p>{{ language.get('display') }}</p>
                    <input id="project-display" type="checkbox" required checked>
                </label>
            </label>

            <div id="project-create-required-2" class="split-3">
                <label class="project-filters split-item" :id="`project-create-filter-${type}`" v-for="(type, i) in projectFilters" :key="i">
                    <p>{{ language.get(type) }}</p>
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
                <p>{{ language.get('spareTime') }}</p>
                <input id="project-spareTime" type="checkbox">
            </label>
        </div>

        <fieldset id="project-create-github" class="project-create-option">
            <legend>{{ language.get('collab') }}</legend>
            <label id="project-create-github-author">
                <p>{{ language.get('collabName') }}</p>
                <input id="project-collab-github" type="text" placeholder="github.com/..."> 
            </label>
            <label id="project-create-github-repo">
                <p>{{ language.get('collabRepo') }}</p>
                <input id="project-collab-repo" type="text" :placeholder="`github.com/${language.get('collabName').toLowerCase()}/...`">
            </label>
        </fieldset>

        <fieldset id="project-create-image" class="project-create-option">
            <legend>{{ language.get('projectImage') }}</legend>
            <p id="file-title">{{ imageValue }}</p>
            <button id="open-file-button" @click="onOpenFileButtonClick">{{ language.get('uploadFile') }}</button>
            <input type="file" id="project-image" accept="image/png, img/jpg, img/jpeg" style="display: none" @change="onOpenFileChange"/>
        </fieldset>
      </fieldset>

      <button id="project-create-submit" @click="onProjectSubmit" type="submit">{{ language.get('registerProject') }}</button>
    </fieldset>
  </div>
</template>

<script>
import { languages, API } from '../../data';
import { Me, Project, DanhoDate } from 'models';

/**@props { language: Map<string, string>, me: Me }
 * @emits create(project: Project)*/
export default {
    name: 'project-create-modal',
    props: {
        language: Map,
        me: Me
    },
    created() {
        const input = document.getElementById('project-crate-image-input');
        this.imageValue = input?.value && !input.value.includes('fakepath') ? input.value : this.language.get('noFile');
    },
    data: () => ({
        projectFilters: ['language', 'projectType'],
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
        async onProjectSubmit() {
            try { var p = await this.createProject(); } 
            catch (err) { alert(err); }
            console.log(p);
            this.$emit('create', p);
        },
        /**@returns { Promise<Project> }*/
        async createProject() {
            const projects = this.me?.projects || await API.getProjects();
            const get = (prop) => document.getElementById(`project-${prop}`);
            const description = {
                Dansk: get('description-Dansk').value.split('\n'),
                English: get('description-English').value.split('\n'),
            };
            const collabValues = {
                github: get('collab-github').value,
                repo: get('collab-repo').value
            };
            const collab = Object.keys(collabValues).filter(p => collabValues[p]).length ? collabValues : null;
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
                if (value === "" || value == null) {
                    throw `${key} must not be null!`;
                }
                else if (key == 'name' && projects.some(p => p.name == value)) {
                    throw `There's already a project called ${value}!`;
                }
                else if (key == 'createdAt' && new Date('2018-8-8').getTime() - new Date(value).getTime() > 0) {
                    throw `Date is too low for your programming expertise!`;
                }
                resultBuilder[key] = value;
            }

            return new Promise(res => {
                const reader = new FileReader();
                reader.readAsArrayBuffer(get('image').files[0]);
                reader.addEventListener('load', () => {
                    const image = Buffer.from(reader.result);
                    const { name } = resultBuilder;
                    const result = new Project(name, { ...resultBuilder, 
                        description, 
                        createdAt: new DanhoDate(...requiredObj.createdAt.split('-').map(s => parseInt(s))),
                        hasLink: get('hasLink').checked, 
                        baseLink: get('baseLink').value, 
                        spareTime: get('spareTime').checked, 
                        image,
                        collab,
                    });
                    result._id = projects.length
                    res(result);
                })
            })

            
        },
        onOpenFileButtonClick() { 
            document.getElementById('project-image').click()
        },
        onOpenFileChange(e) {
            const file = e.srcElement.value;
            const fileSplit = file.split('\\');
            const fileName = fileSplit[fileSplit.length - 1];
            document.getElementById('file-title').textContent = fileName;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

#project-create {
    position: relative;
    display: none;
    margin: 0 auto;
    z-index: 4;

    @include height-width(100%, 100%);

    & > * { position: absolute; height: inherit; }
    &-required, &-optional { top: -2em; position: relative; height: 100%; }

    &-content {
        display: grid;
        grid-template-columns: 60% 39%;
        grid-template-rows: 5% 85% 5%;

        @include max-height-width(90%, 50%);
        @include height-width(100%, 50%);

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
        &-2 {
            input { height: 20px; }
            label {
                height: 75px;
            }
        }
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
#project-create-github,
.project-create-option,
.split-item {
    display: inline-block;
}

#project-create-display {
    display: inline;
    position: relative;

    & > * { display: inherit; }
}

.project-description { height: 100%; }

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

#project-create-github {
    height: 25%;


    label {
        display: inline-block;
        p { 
            text-align: center; 
            display: block; 
            @include margin-block(0, 0);
        }
    }
}

label {
    margin: 2%;

    & > p { font-weight: bold; }
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