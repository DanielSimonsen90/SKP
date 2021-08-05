<template>
  <div :id="`project-${crud}`" class="project-modify">
    <fieldset :id="`project-${crud}-content`" class="modal-content project-modify-content">
      <legend>{{ language.get(crud) }} {{ language.get('project') }}</legend>

      <fieldset :id="`project-${crud}-required`" class="project-modify-required">
            <legend>{{ language.get('projectInfo') }}</legend>
            <label :id="`project-${crud}-required-1`" class="project-modify-required-1">
                <p>{{ language.get('name') }}</p>
                <input :id="`project-${crud}-name`" type="text" required :placeholder="language.get('projectNamePlaceholder')" :value="project ? project.name : ''">

                <label :id="`project-${crud}-display-container`" class="project-modify-display">
                    <p>{{ language.get('display') }}</p>
                    <input :id="`project-${crud}-display`" type="checkbox" required :checked="project ? project.display : true">
                </label>
            </label>

            <div :id="`project-${crud}-required-2`" class="split-3 project-modify-required-2">
                <label class="project-filters split-item" :id="`project-${crud}-filter-${type}`" v-for="(type, i) in projectFilters" :key="i">
                    <p>{{ project ? project[type] : language.get(type) }}</p>
                    <input :id="`project-${crud}-${type}`" type="text" :list="`filter-data-${type}`" required :value="project ? project[type] : ''">
                    <datalist :id="`filter-data-${crud}-${type}`">
                        <option v-for="(item, j) in getProjectFilterOptions(type)" :key="j">{{ item }}</option>
                    </datalist>
                </label>
                <label :id="`project-${crud}-createdAt-container`">
                    <p>{{ language.get('createdAt') }}</p>
                    <input :id="`project-${crud}-createdAt`" type="date" required :value="project ? project.createdAt.toString('-').split('-').reverse().join('-') : currentDate">
                </label>
            </div>

            <div :id="`project-${crud}-required-3`" class="split-2 project-modify-required-3">
                <label class="project-description split-item" :id="`project-${crud}-description-${lang}-container`" v-for="(lang, i) in supportedLanguages" :key="i">
                    <p>{{ language.get(`description-${lang}`) }}</p>
                    <textarea :id="`project-${crud}-description-${lang}`" :name="lang" 
                        cols="30" rows="10" 
                        :placeholder="languages.get(lang).get('languagePlaceholder')" 
                        :value="project ? project.description[lang] : ''"
                    >
                    </textarea>
                </label>
            </div>
      </fieldset>
      
      <fieldset :id="`project-${crud}-optional`" class="project-modify-optional">
        <legend>{{ language.get('projectOptional') }}</legend>

        <div class="project-modify-option">
            <label :id="`project-${crud}-baseLink-container`">
                <p>{{ language.get('baseLink') }}</p>
                <input :id="`project-${crud}-baseLink`" type="text" placeholder="/Education/Hovedforløb 69/..." :checked="project ? project.baseLink : ''">
            </label>
            <label :id="`project-${crud}-hasLink-container`">
                <p>{{ language.get('hasLink') }}</p>
                <input :id="`project-${crud}-hasLink`" type="checkbox" :checked="project ? project.link != undefined || project.hasLink : false">
            </label>
            <label id="project-modify-spareTime">
                <p>{{ language.get('spareTime') }}</p>
                <input :id="`project-${crud}-spareTime`" type="checkbox" :checked="project ? project.spareTime : false">
            </label>
        </div>

        <fieldset :id="`project-${crud}-github`" class="project-modify-option">
            <legend>{{ language.get('collab') }}</legend>
            <label :id="`project-${crud}-github-author-container`">
                <p>{{ language.get('collabName') }}</p>
                <input :id="`project-${crud}-github-author`" type="text" placeholder="github.com/..." :value="project && project.collab ? project.collab.github : ''"> 
            </label>
            <label :id="`project-${crud}-github-repo-container`">
                <p>{{ language.get('collabRepo') }}</p>
                <input :id="`project-${crud}-github-repo`" type="text" :placeholder="`github.com/${language.get('collabName').toLowerCase()}/...`" :value="project && project.collab ? project.collab.repo : ''">
            </label>
        </fieldset>

        <fieldset :id="`project-${crud}-file-container`" class="project-modify-option">
            <legend>{{ language.get('projectImage') }}</legend>
            <p :id="`${crud}-file-title`">{{ imageValue }}</p>
            <button :id="`${crud}-open-file-button`" @click="onOpenFileButtonClick">{{ language.get('uploadFile') }}</button>
            <input type="file" :id="`project-${crud}-image`" accept="image/png, img/jpg, img/jpeg" style="display: none" @change="onOpenFileChange"/>
        </fieldset>
        
        <div class="project-modify-image-container" v-if="imageValue != language.get('noFile')">
            <img :src="`data:image/png;base64,${this.image}`" />
        </div>
      </fieldset>


      <button :id="`project-${crud}-submit`" class="project-modify-submit" @click="onProjectSubmit" type="submit">{{ language.get(crud) }} {{ language.get('project') }}</button>
    </fieldset>
  </div>
</template>

<script>
import { languages, API } from '../../data';
import { Me, Project, DanhoDate } from 'models';

/**@props { language: Map<string, string>, me: Me }
 * @emits create(project: Project)
 * @emits update(project: Project)*/
export default {
    name: 'modify-modal',
    props: {
        language: Map,
        me: Me,
        project: Project,
        crud: String /*'create' | 'update'*/
    },
    data: () => ({
        projectFilters: ['language', 'projectType'],
        languages,
    }),
    computed: {
        supportedLanguages() {
            return languages.keys();
        },
        currentDate() {
            const date = new Date();
            return new DanhoDate(date.getFullYear(), date.getMonth() + 1, date.getDate()).toStringReverse();
        },
        imageValue() {
            const input = document.getElementById(`project-${this.crud}-image`);
            return input?.value && !input.value.includes('fakepath') ? input.value : this.project?.image ? this.language.get('previousImage') : this.language.get('noFile');
        }
    },
    asyncComputed: {
        async image() {
            return new Promise(resolve => {
                if (this.imageValue == this.language.get('previousImage')) {
                    return resolve(this.project.image);
                }

                if (!this.get('image') || !this.get('image').files[0]) return null;

                const reader = new FileReader();
                reader.readAsArrayBuffer(this.get('image').files[0]);
                reader.addEventListener('load', () => resolve(Buffer.from(reader.result)))
            });
        }
    },
    methods: {
        /**@param {'language' | 'projectType'} type*/
        getProjectFilterOptions(type) {
            return this.me.projects?.reduce((result, p) => {
                if (!result.includes(p[type]))
                    result.push(p[type]);
                return result;
            }, []).sort() || [];
        },
        async onProjectSubmit() {
            const p = await this.createProject().catch(err => { console.error(err); alert(err); })
            this.$emit(this.crud, p);
        },
        get(prop) {
            return document.getElementById(`project-${this.crud}-${prop}`)
        },
        /**@returns { Promise<Project> }*/
        async createProject() {
            const projects = this.me?.projects || await API.getProjects();
            const { get } = this;
            const description = {
                Dansk: get('description-Dansk').value.split('\n'),
                English: get('description-English').value.split('\n'),
            };
            const collabValues = {
                github: get('github-author').value,
                repo: get('github-repo').value
            };
            const collab = Object.keys(collabValues).filter(p => collabValues[p]).length ? collabValues : null;
            const requiredObj = { 
                name: get('name').value, 
                display: get('display').checked, 
                language: get('language').value, 
                projectType: get('projectType').value, 
                createdAt: this.project ? this.project.createdAt.toStringReverse() : get('createdAt').value, 
                
                descriptionDansk: description.Dansk[0], 
                descriptionEnglish: description.English[0] 
            };
            const required = new Map(Object.keys(requiredObj).map(prop => [prop, requiredObj[prop]]));

            let resultBuilder = {};
            for (const [key, value] of required) {
                if (value === "" || value == null) throw `${key} must not be null!`;
                else if (key == 'name' && this.crud == 'create' && projects.some(p => p.name == value)) throw `There's already a project called ${value}!`;
                else if (key == 'createdAt' && new Date('2018-8-8').getTime() - new Date(value).getTime() > 0) {
                    throw `Date is too low for your programming expertise!`;
                }

                resultBuilder[key] = value;
            }

            const image = await this.image;

            const { name } = resultBuilder;
            const shell = new Project(name, { ...resultBuilder, 
                description, 
                createdAt: new DanhoDate(...requiredObj.createdAt.split('-').map(s => parseInt(s))),
                hasLink: get('hasLink').checked, 
                baseLink: get('baseLink').value, 
                spareTime: get('spareTime').checked, 
                image,
                collab,
            });
            shell._id = projects.length;

            console.log('returning');
            return Object.assign(this.project, shell);
        },
        onOpenFileButtonClick() { 
            document.getElementById(`project-${this.crud}-image`).click()
        },
        onOpenFileChange(e) {
            const file = e.srcElement.value;
            const fileSplit = file.split('\\');
            const fileName = fileSplit[fileSplit.length - 1];
            document.getElementById(`${this.crud}-file-title`).textContent = fileName;
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

.modal.project-modify {
    margin: 0 auto;
    z-index: 4;
    @include height-width(125%, 100%);
}

.project-modify {
    display: none;


    & > * { position: absolute; height: 92.5%; }
    &-required, &-optional { 
        top: -2em; 
        position: relative; 
        height: 100%; 
    }

    &-content {
        display: grid;
        grid-template-columns: 60% 39%;
        grid-template-rows: 5% 78% 10% 5%;

        @include max-height-width(95%, 50%);
        @include height-width(100%, 50%);

        legend {
            width: max-content;
            grid-column: 2;
            grid-row: 1;
        }
    }

    .project-modify-required {
        grid-row: 2;
        grid-column: 1;

        & > * { position: relative; }
        &-1 input { font-size: 24px; }
        &-2 {
            input { height: 20px; }
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
        grid-row-start: 3;
        grid-row-end: 3;
        grid-column: 1 / 3;
        height: 100%;
        font-size: 24px;
    }
}

.project-modify-required-1, 
.project-modify-github,
.project-modify-option,
.split-item {
    display: inline-block;
}

.project-modify-display {
    display: inline;
    position: relative;

    & > * { display: inherit; }
}

.project-modify-option {
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

.project-modify-github {
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

.project-modify-image-container > img {
    @include height-width(27.5%, 100%);
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