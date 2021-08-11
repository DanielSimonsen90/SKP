<template>
  <div id="home">
      <h1>{{ language.get('homeTitle') }}</h1>
      <content class="home-content">
        <who-dis :data="whoDisData" :language="language" />
        <portrait id="portrait" />
      </content>
      <content>
        <plan :me="me" :language="language" />
        <danho-socials id="socials" :me="me" :language="language" :displayIcons="true" />
      </content>
  </div>
</template>

<script>
import { Me, ProjectCollection } from 'models';
import WhoDis from '../About/Who.vue';
import Portrait from '../Shared/Portrait.vue';
import Plan from '../Plan';
import DanhoSocials from '../Shared/Navigation/DanhoSocials.vue';

export default {
  components: { WhoDis, Portrait, Plan, DanhoSocials },
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
    })
  }
}
</script>

<style lang="scss">
@import '@/scss/mixins';

.home-content {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  padding: 1%;
  height: 50%;

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