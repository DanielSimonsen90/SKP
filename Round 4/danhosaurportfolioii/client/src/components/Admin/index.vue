<template>
  <div id="admin">
      <modify-modal :crud="'create'" :language="language" :me="me" @create="onProjectCreate"/>
      <modify-modal :crud="'update'" :language="language" :me="me" @update="onProjectUpdate" :project="project"/>

      <button @click="openModal('project-create')">{{ language.get('create') }} {{ language.get('project') }}</button>
      <project-table v-if="projects"
        :projects="projects" :language="language" :me="me" 
        @navigate="onNavigate" @update="onUpdateRequest" @delete="onProjectDelete"
      />
  </div>
</template>

<script>
import Vue from 'vue';

import ModifyModal from './ModifyModal.vue';
import ProjectTable from './ProjectTable.vue';

import { Me, Project } from 'models';
import { API } from '../../data';

/**@param {Vue} component
 * @param {'create' | 'update' | 'delete'} type
 * @param {Project} project
 * @param {Project} preProject*/
function crudLog(component, type, project, preProject) {
    const message = `Successfully ${type}d ${project.name}${preProject?.name && preProject.name != project.name ? `(${preProject.name})` : ''} (${project._id})`;
    const crudMap = new Map([
        ['create', 'green'], 
        ['update', 'yellow'], 
        ['delete', 'red']
    ]);

    console.log(`%c[Portfolio]: %c${message}`, "color: cornflowerblue", crudMap.get(type));

    if (component.$props.me) API.getProjects().then(projects => {
        component.$props.me.projects = projects;
        component.$forceUpdate();
    });
}

/**@props { language: Map<string, string> }
 * @emits navigate(link: string)*/
export default {
    components: { ProjectTable, ModifyModal },
    props: {
        language: Map,
        me: Me
    },
    data: () => ({
        project: null
    }),
    asyncComputed: {
        async projects() {
            return this.me?.projects || await API.getProjects();
        }
    },
    methods: {
        openModal(modalWrapper) {
            const admin = document.getElementById('admin');
            const wrapper = document.getElementById(modalWrapper);
            const wrapperContent = document.getElementById(`${modalWrapper}-content`);

            wrapperContent.classList.toggle('modal-fadeout');
            let showFadeout = true;
            let showing = false;

            const toggleModal = async () => {
                if (showFadeout) {
                    wrapperContent.classList.toggle('modal-fadeout');
                    await new Promise((resolve, reject) => {
                        setTimeout(() => resolve(), 500);
                    })
                }
                for (let i = 0; i < admin.children.length; i++) {
                    admin.children[i].classList.toggle('modal');
                }

                admin.classList.toggle('modal');
                wrapperContent.classList.toggle('show-modal');
                showing = !showing;
                showFadeout = !showFadeout;

                wrapper.style.display = showing ? 'block' : 'none';

            }
            const removeAppListenAndToggle = () => {
                toggleModal();
                wrapper.removeEventListener('click', stopModalListener);
            }
            const stopModalListener = (e) => {
                if (e.target == wrapper) removeAppListenAndToggle();
            }

            this.removeAppListenAndToggle = removeAppListenAndToggle;

            wrapper.addEventListener('click', stopModalListener);
            toggleModal();
        },
        /**@param {Project} project*/
        async onProjectCreate(project) {
            await API.createProject(project);
            crudLog(this, 'create', project);
            this.removeAppListenAndToggle();
        },
        onUpdateRequest(project) {
            this.project = project;
            this.openModal('project-update')
        },
        async onProjectUpdate(project) {
            console.log({ pre: this.project, current: project });
            await API.updateProject(project);
            crudLog(this, 'update', project, this.project);
            this.project = null;
            this.removeAppListenAndToggle();
        },
        async onProjectDelete(project) {
            await API.deleteProject(project);
            crudLog(this, 'delete', project);
        },
        onNavigate(link) {
            this.$emit('navigate', link)
        }
    }
}
</script>

<style lang="scss">
#admin {
    position: absolute;
    width: 100%;

    & > button {
        position: absolute;
        left: 50%;
        transform: translateX(-50%);

        &.modal {
            width: auto;
        }
    }
}
</style>