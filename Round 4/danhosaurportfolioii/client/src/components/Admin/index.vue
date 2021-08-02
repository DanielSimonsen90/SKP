<template>
  <div id="admin">
      <project-create-modal :language="language" :me="me" @create="onProjectCreate"/>
      <button @click="openModal('project-create')">{{ language.get('registerProject') }}</button>
      <project-table :projects="projects" :language="language" @navigate="onNavigate" v-if="projects" />
  </div>
</template>

<script>
import ProjectCreateModal from './CreateModal.vue';

import { Me, Project } from 'models';
import { API } from '../../data';
import ProjectTable from './ProjectTable.vue';

/**@props { language: Map<string, string> }
 * @emits navigate(link: string)*/
export default {
    components: { ProjectCreateModal, ProjectTable },
    props: {
        language: Map,
        me: Me
    },
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
        onProjectCreate(project) {
            API.createProject(project);
            this.removeAppListenAndToggle();
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
}
</style>