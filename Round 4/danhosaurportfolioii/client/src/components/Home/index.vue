<template>
  <div id="home">
      <h1>{{ language.get('homeTitle') }}</h1>
      <content class="basic-about">
        <who-dis :data="whoDisData" :language="language" />
        <portrait id="portrait" />
      </content>
      <content class="basic-projects">
        <h3> 
          {{ language.get('myLast') }} 
          {{ filteredProjects.length }} 
          {{ language.get('projects') }}
        </h3>
        <project-card-container v-if="filteredProjects.length" :projects="filteredProjects" :language="language" :languageValue="languageValue" :displayButtons="false" />
        <p v-else>{{ language.get('loadingProjects') }}</p>
      </content>
      <content class="basic-plan-socials">
        <plan :me="me" :language="language" />
        <danho-socials id="socials" :me="me" :language="language" :displayIcons="true" />
      </content>
  </div>
</template>

<script>
import { Me, ProjectCollection } from 'danhosaurportfolio-models';
import WhoDis from '../About/Who.vue';
import ProjectCardContainer from '../Admin/ProjectCardContainer.vue';
import Portrait from '../Shared/Portrait.vue';
import Plan from '../Plan';
import DanhoSocials from '../Shared/Navigation/DanhoSocials.vue';

export default {
  components: { WhoDis, ProjectCardContainer, Portrait, Plan, DanhoSocials },
  props: {
    me: Me,
    projects: ProjectCollection,
    language: Map,
    languageValue: String,
    projectLanguage: String,
    projectType: String
  },
  computed: {
    whoDisData: (_this) => ({
      title: _this.language.get('whoDisTitle'),
      content: _this.language.get('whoDisContent')(_this.me),
      projectString: _this.language.get('whoDisProjectString'),
      projects: ['Pingu', 'DanhoLibrary', 'MyWatch']
    }),
    filteredProjects: (_this) => 
      _this.projects.filter(p => p.display)
      .reverse()
      .slice(0, 6)
      .map((p, i) => ({ ...p, index: i }))
  }
}
</script>

<style lang="scss">
@import '@/scss/mixins';

#home {
  > content { 
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }

  #project-card-container {
    position: relative;
    top: unset;
    left: unset;
    width: 80%;

    .project-card {
      width: 29.5%;

      header .checkboxes {
        height: 125%;
        width: 27.5%;

        label {
          margin: 0;
        }
      }
    }
  }
}

.basic {
  &-about {
    justify-content: space-around !important;
    padding: 1%;
    height: 50%;
    flex-direction: row !important;

    > * {
      width: 45% !important;
      position: relative !important;
      max-height: 33%;
      height: inherit;
      overflow: auto;

      .link-item {
        box-shadow: unset;
        border-radius: unset;
      }
    }

    #portrait {
      @include max-height-width(15%, 15%);
    }
  }
}

#socials {
  display: flex;
  flex-direction: row;
  width: fit-content;
  padding-inline: 0;
  justify-content: center;

  li {
    display: flex;
    flex-direction: row;
    justify-content: flex-start;
    align-items: center;
    font-size: 24px;
    width: 10%;

    > * {
      width: 33%;
    }
    .socials-icon {
      margin-right: -10%;
    }
    a {
      width: 100%;
      font-size: 150%;
    }
  }
}
</style>