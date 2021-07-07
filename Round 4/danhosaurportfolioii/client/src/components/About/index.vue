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
import { Me, Item } from 'models';
import { locationCollection } from '../../data';

import WhoDis from './Who.vue'
import Portrait from '../Shared/Portrait.vue';
import Sparetime from './Sparetime.vue';
import Contact from './Contact.vue';

export default {
    components: { WhoDis, Portrait, Sparetime, Contact },
    props: {
        me: Me,
        language: Map
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
                title: this.language.get('spareTimeTitle'),
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

#about {
    position: absolute;
    min-width: 99%;
    min-height: 72%;
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

    grid-column: 1 / 3;
    grid-row: 2;

    color: $theme-secondary;
    text-decoration: none;
    font-size: 55px;
    text-align: center;

    &:hover {
        color: $color-click-me;
        text-decoration: underline;
    }
}

.article-content {
    height: 100%;
}

fieldset {
    @extend %hoverable-border;
    @extend %shadow-me;

    display: inline;

    background-color: $fieldset-background;
    border-color: $theme-tertiary;

    word-wrap: break-word;
    margin: 5px;

    
    &:hover {
        border-color: $theme-secondary;

        legend {
            @extend %hoverable-color;

            color: $theme-primary !important;
        }
    }
}
legend {
    color: $theme-secondary;
    font-weight: bold;
    font-size: 150%;


    &:hover {
        color: $theme-primary;
    }
}
</style>