<template>
  <div class="error" @click="onClick">
      <h1>You've reached a strange place...</h1>
      <h5>I don't think you should've been here...</h5>
  </div>
</template>

<script>
import { Me, ProjectCollection } from 'danhosaurportfolio-models'

/**@props: { me: Me }
 * @emits navigate('Home')*/
export default {
  props: {
    me: Me,
    language: Map,
    languageValue: String,
    projcets: ProjectCollection
  },
  methods: {
    onClick() {
      this.$emit('navigate', 'Home');
    }
  }
}
</script>

<style lang="scss">
@import '@/scss/partials';

.error {
  @extend %clickable;
  @extend %rounded;
  @extend %shadow-me;

  position: absolute;
  background: rgb(77, 21, 32);
  color: rgb(207, 40, 74);
  border: 2px solid rgb(143, 29, 50);
  width: fit-content;
  min-height: max-content !important;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  padding: 2%;

  &:hover h1 {
    text-decoration: underline;
  }
}
</style>