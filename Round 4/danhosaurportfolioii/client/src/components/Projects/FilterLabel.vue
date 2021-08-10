<template>
  <label>
    <b>{{ display }}</b>
    <input class="project-filter-input" type="text" :list="`filter-data-${type}`" :value="inputValue" @input="valueChanged">
    <datalist :id="`filter-data-${type}`">
      <option :value="item" v-for="(item, i) in getProjects(type)" :key="i"></option>
    </datalist>
  </label>
</template>

<script>
import { Me } from 'models';

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
    methods: {
        /**@param {'projectLanguage' | 'projectType'} type*/
        async getProjects(type) {
            /**@param {String} type
             * @returns {String} */
            const getType = (type) => type == 'projectLanguage' ? 'language' : type;
            type = getType(type);
            const filter = getType(Object.keys(this.filterFrom)[0]);

            if (!this.me || this.me.projects.then) return [];

            return [...this.me.projects?.reduce?.((result, p) => {
                if (!result.includes(p[type]) && p[filter] == this.filterFrom[filter])
                    result.push(p[type])
                return result;
            }, []).sort() || []];
        },
        valueChanged(e) {
            this.$emit('change', this.type, e.target.value);
        }
    }
}
</script>

<style lang="scss">
.project-filter-input {
    height: 16px;
}
</style>