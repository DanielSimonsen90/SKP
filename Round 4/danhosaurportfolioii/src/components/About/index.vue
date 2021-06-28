<template>
  <div id="about">
      <who-dis :data="whoDis"/>
      <sparetime :data="spareTime" />
      <portrait :style="portraitStyle" id="about-portrait"/>
      <p id="occupation" @click="toPlan">
          {{ occupationStrings[0] }}
          <b>{{ me.occupation }}</b>
          {{ occupationStrings[1] }}
          <b>{{ occupationUntil }}</b>
      </p>
      <contact :data="contact" />
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
        me: Me
    },
    computed: {
        whoDis(_this) {
            const title = 'Hvem er jeg?';
            const content = [
                `Mit navn er ${_this.me.name}, og jeg er en ${_this.me.age} årig ung mand, som tager Datatekniker med speciale i programmerings uddannelsen på Techcollege, Aalborg.`,
                `Jeg har ${_this.me.codingFor} års erfaring med programmering, og bruger rigtig meget af min fritid på forskellige projekter.`,
                `Objekt Orienteret Programmering har jeg stor glæde for, og bruger rigtig meget tid på at gøre min kode så fleksibelt som muligt via generics & callbacks.`,
                `Webudvikling, og generelt JavaScript/TypeScript, er alle noget jeg virkelig elsker at lege med. Det kan måske ses på hjemmesiden?`
            ];
            const projectString = `Nogle af mine personlige ynglingsprojekter indgår:`;
            const projects = ['Pingu', 'DanhoLibrary', 'MyWatch'];
            return { title, content, projects, projectString };
        },
        portraitStyle: () => ({
            'justify-self': 'center',
            'top': '7.5%',
            'grid-column': 3,
            'grid-row': 1
        }),
        spareTime() {
            const title = 'Fritid';
            const content = [
                new Item('Discord', "Jeg bruger meget af min tid på Discord. Dette inkluderer min interesse for Discord bots, måden Discord er sat op på via components, og generelle permission handling."),
                new Item('FL Studio', "Jeg tilbringer nogle gange min fritid på at lave min egen musik, som jeg sætter på services from Spotify & SoundCloud."),
                new Item('Overwatch', "Som programmør er man naturligt interesseret i spil. Overwatch er det spil, jeg spiller mest sammen med mine venner." )
            ];

            return { title, content }
        },
        contact: (_this) => ({
            title: 'Kontakt',
            me: _this.me
        }),
        occupationStrings: () => ['I øjeblikket er jeg på', 'indtil'],
        occupationUntil: (_this) => locationCollection.find(i => i.course == _this.me.occupation).end.toString()
    },
    methods: {
        toPlan() {
            this.$emit('navigate', 'Plan')
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