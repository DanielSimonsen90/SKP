<template>
  <fieldset  :id="id">
      <legend>{{ data.title }} </legend>
      <content class="article-content">
        <danho-socials :me="data.me" :displayIcons="true" :language="language"/>
      </content>
  </fieldset>
</template>

<script>
import { Me } from 'models';
import DanhoSocials from '../Shared/Navigation/DanhoSocials.vue';

export default {
  components: { DanhoSocials },
    props: {
        data: {
            title: String,
            me: Me
        },
        language: Map
    },
    data: () => ({
        id: 'contact'
    })
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';

#contact {
    display: block;
    position: relative;
    top: -5%;
    height: max-content;
    width: 58%;

    grid-column: 3;
    grid-row: 2;

    ul {
        padding-inline-start: 0;

        li {
            @extend %click-me;
            display: block;
            padding: 0 2%;
            font-size: 24px;
        }
    }
}

</style>