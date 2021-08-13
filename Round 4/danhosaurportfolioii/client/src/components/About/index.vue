<template>
  <div id="about">
      <who-dis :data="whoDis" :language="language"/>
      <sparetime :data="spareTime" />
      <portrait :style="portraitStyle" id="about-portrait" @click="onPortraitClick"/>
      <p id="occupation" @click="toPlan">
          {{ occupationStrings[0] }}
          <b>{{ me.occupation }}</b>
          {{ occupationStrings[1] }}
          <b>{{ occupationUntil }}</b>
      </p>
      <contact :data="contact" :language="language" />
  </div>
</template>

<script>
import { Me, Item, ProjectCollection } from 'danhosaurportfolio-models';
import { locationCollection } from '../../data';

import WhoDis from './Who.vue'
import Portrait from '../Shared/Portrait.vue';
import Sparetime from './Sparetime.vue';
import Contact from './Contact.vue';

export default {
    components: { WhoDis, Portrait, Sparetime, Contact },
    props: {
        me: Me,
        language: Map,

        projects: ProjectCollection,
        languageValue: String
    },
    computed: {
        whoDis(_this) {
            return {
                title: this.language.get('whoDisTitle'),
                content: this.language.get('whoDisContent')(_this.me),
                projectString: this.language.get('whoDisProjectString'),
                projects: ['Pingu', 'DanhoLibrary', 'MyWatch']
            }
        },
        portraitStyle: () => ({
            'justify-self': 'center',
            'top': '7.5%',
            'grid-column': 3,
            'grid-row': 1
        }),
        spareTime() {
            return {
                title: this.language.get('spareTime'),
                content: ['Discord', 'FL Studio', 'Overwatch'].map(i => new Item(i, this.language.get(`spareTime${i.replace(/ +/, '')}`)))
            }
        },
        contact: (_this) => ({
            title: _this.language.get('contact'),
            me: _this.me
        }),
        occupationStrings: (_this) => _this.language.get('occupationStrings'),
        occupationUntil: (_this) => locationCollection.find(i => i.course == _this.me.occupation).end.toString()
    },
    methods: {
        toPlan() {
            this.$emit('navigate', 'Plan')
        },
        onPortraitClick() {
            this.$emit('navigate', 'Admin')
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

#about {
    position: absolute;
    @include min-height-width(72%, 99%);
    height: inherit;
    text-align: left;
    left: 0;

    display: grid;
    grid-template-columns: 50% 33% 25%;
    grid-template-rows: 70% 30%;

    > * {
        max-height: 90%;
    }

    .link-item {
        box-shadow: unset;
        border-radius: unset;
    }
}
#occupation {
    @extend %click-me;
    @extend %hoverable-color;

    grid-column: 1 / 3;
    grid-row: 2;

    color: $theme-secondary;
    text-decoration: none;
    font-size: 50px;
    text-align: center;
    transition: color $transition-hover, text-decoration $transition-hover * 2;

    &:hover {
        color: $color-click-me;
        text-decoration: underline;
    }
}

.article-content {
    height: 100%;
}
</style>