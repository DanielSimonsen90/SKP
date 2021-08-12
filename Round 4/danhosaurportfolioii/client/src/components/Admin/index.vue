<template>
  <div id="admin">
      <div id="admin-content" v-if="loggedIn">
        <modify-modal :crud="'create'" :language="language" :projects="projects" @create="onProjectCreate"/>
        <modify-modal :crud="'update'" :language="language" :projects="projects" @update="onProjectUpdate" :project="project"/>

        <button @click="openModal('project-create')">{{ language.get('create') }} {{ language.get('project') }}</button>
        <project-card-container v-if="projects && projects.length"
            :projects="projects" :language="language" :languageValue="languageValue" :displayButtons="true"
            @navigate="onNavigate" @update="onUpdateRequest" @delete="onProjectDelete"
        />
      </div>
      <admin-login v-else @admin-login="onLoggedIn" />
  </div>
</template>

<script>
import ModifyModal from './ModifyModal.vue';
import ProjectCardContainer from './ProjectCardContainer.vue';
import AdminLogin from './Login.vue';

import { ProjectCollection, Project, Me } from 'danhosaurportfolio-models';
import { API } from '../../data';

/**@param {'create' | 'update' | 'delete'} type
 * @param {Project} project
 * @param {Project} preProject*/
function crudLog(type, project, preProject) {
    const message = `Successfully ${type}d ${project.name}${preProject?.name && preProject.name != project.name ? `(${preProject.name})` : ''} (${project._id})`;
    const crudMap = new Map([
        ['create', 'green'], 
        ['update', 'yellow'], 
        ['delete', 'red']
    ]);

    console.log(`%c[Portfolio]: %c${message}`, "color: cornflowerblue", crudMap.get(type));
}

/**@props { language: Map<string, string> }
 * @emits navigate(link: string)
 * @emits refresh(refreshComponent: () => void)*/
export default {
    components: { ProjectCardContainer, ModifyModal, AdminLogin },
    props: {
        language: Map,
        projects: ProjectCollection,
        languageValue: String,
        
        me: Me
    },
    data: () => ({
        project: null,
        loggedIn: false
    }),
    methods: {
        onLoggedIn(admin) {
            this.loggedIn = true;
        },
        openModal(modalWrapper) {
            const admin = document.getElementById('admin-content');
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
            crudLog('create', project);
            this.removeAppListenAndToggle();
            this.updateProjects();
        },
        onUpdateRequest(project) {
            this.project = project;
            this.openModal('project-update')
        },
        async onProjectUpdate(project) {
            console.log({ pre: this.project, current: project });
            await API.updateProject(project);
            crudLog('update', project, this.project);
            this.project = null;
            this.removeAppListenAndToggle();
            this.updateProjects();
        },
        async onProjectDelete(project) {
            await API.deleteProject(project);
            crudLog('delete', project);
            this.updateProjects();
        },
        onNavigate(link) {
            this.$emit('navigate', link)
        },
        async updateProjects() {
            this.$emit('refresh');
        }
    }
}
</script>

<style lang="scss">
#admin {
    position: absolute;
    width: 100%;
    height: inherit;
    left: 0;

    button {
        min-height: 35px;
    }

    #admin-content > button {
        position: absolute;
        left: 50%;
        transform: translateX(-50%);

        &.modal {
            width: auto;
        }
    }
}

#admin-content.modal {
    height: 200%;
}
</style>