<template>
  <label>
    <b>{{ display }}</b>
    <input type="text" :list="`filter-data-${type}`" :value="inputValue" @input="valueChanged">
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
        me: Me
    },
    methods: {
        /**@param {'projectLanguage' | 'projectType'} type*/
        getProjects(type) {
            type = type == 'projectLanguage' ? 'language' : type;
            return [this.all, ...this.me.projects.reduce((result, p) => {
                if (!result.includes(p[type]))
                    result.push(p[type])
                return result;
            }, []).sort()];
        },
        valueChanged(e) {
            this.$emit('change', this.type, e.target.value);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/variables';

label {
    width: 100%;
    display: block;
    text-align: left;

    input {
        background-color: lighten($background-secondary, $theme-difference * 2);
        color: $color;
        
        &:hover {
            background-color: $background-secondary;
        }
    }

    b {
        margin: 0 10px;
    }
}
</style>