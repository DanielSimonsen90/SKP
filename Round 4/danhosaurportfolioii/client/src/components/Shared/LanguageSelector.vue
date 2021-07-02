<template>
  <label>
      <b>{{ languageLabel }}</b>
      <input type="text" list="languages-list" :value="languageValue" @input="valueChanged">
      <datalist id="languages-list">
          <option :value="item" v-for="(item, i) in supportedLanguages" :key="i"></option>
      </datalist>
  </label>
</template>

<script>
import { languages } from '../../data';

/**@props { language: Map, languageValue: String }
 * @emits change(value: string)*/
export default {
    props: {
        language: Map,
        languageValue: String
    },
    computed: {
        supportedLanguages() {
            let result = [];
            for (const [lang] of languages) {
                result.push(lang);
            }
            return result;
        },
        languageLabel() { 
            return this.language.get('languageLabel');
        }
    },
    methods: {
        valueChanged(e) {
            this.$emit('change', e.target.value);
        }
    }
}
</script>

<style>

</style>