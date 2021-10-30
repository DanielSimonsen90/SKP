<template>
  <label>
    <b>{{ display }}</b>
    <input class="project-filter-input" type="text" :list="`filter-data-${type}`" :value="inputValue" @input="valueChanged">
    <datalist :id="`filter-data-${type}`">
      <option :value="item" v-for="(item, i) in getProjects" :key="i"></option>
    </datalist>
  </label>
</template>

<script>
import { Me } from 'danhosaurportfolio-models';

/**@props: { display: String, type: 'projectLanguage' | 'projectType', all: String, me: Me }
 * @emits change(type: 'language' | 'projectType', value: String)*/
export default {
    name: 'filter-label',
    props: {
        display: String,
        type: String,
        inputValue: String,
        me: Me,
        filterFrom: Object
    },
    asyncComputed : {
        /**@param {'projectLanguage' | 'projectType'} type*/
        async getProjects() {
            /**@param {String} type
             * @returns {String} */
            const getType = (type) => type == 'projectLanguage' ? 'language' : type;
            const type = getType(this.type);
            const filter = getType(Object.keys(this.filterFrom)[0]);

            if (!this.me || this.me.projects.then) return [];

            console.log("I now make array");
            return new Set(this.me.projects?.map(p => (!this.filterFrom[filter] || this.filterFrom[filter] == p[filter]) && p[type]).filter(v => v) ?? []);
        },
    },
    methods: {
        valueChanged(e) {
            const datalist = document.querySelector("#filter-data-projectType");
            if (!datalist.children[0]) {
                this.$forceUpdate();
            }
            this.$emit('change', this.type, e.target.value);
        }
    }
}
</script>

<style lang="scss">

</style>