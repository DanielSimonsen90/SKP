<template>
  <div id="admin">
      <project-create :language="language" :me="me" />

      <button @click="openCreateModal">Register Project</button>
  </div>
</template>

<script>
import ProjectCreate from './Create.vue';

import { Me } from 'models';

/**@props { language: Map<string, string> }*/
export default {
    components: { ProjectCreate },
    props: {
        language: Map,
        me: Me
    },
    methods: {
        openCreateModal() {
            const app = document.getElementById('app');
            const create = document.getElementById('project-create');
            const admin = document.getElementById('admin');
            create.classList.toggle('modal-fadeout');
            let showFadeout = true;
            let showing = false;

            const toggleModal = async () => {
                if (showFadeout) {
                    create.classList.toggle('modal-fadeout');
                    await new Promise((resolve, reject) => {
                        setTimeout(() => resolve(), 500);
                    })
                }
                admin.classList.toggle('modal');
                create.classList.toggle('show-modal');
                showing = !showing;
                showFadeout = !showFadeout;
            }
            const stopModalListener = (e) => {
                if (e.target == admin) {
                    toggleModal();
                    app.removeEventListener('click', stopModalListener);
                }
            }

            app.addEventListener('click', stopModalListener);
            toggleModal();
        }
    }
}
</script>

<style>

</style>