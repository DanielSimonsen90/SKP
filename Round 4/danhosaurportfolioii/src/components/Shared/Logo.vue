<template>
  <span id="logo-container" @mouseover="onMouseOver" @mouseout="onMouseOut">
    <img id="logo" :src="logo">
  </span>
</template>

<script>
/**@props { hovering: Boolean }
 * @emits hover(hovering: boolean)*/
export default {
    props: {
        hovering: Boolean
    },
    computed: {
        logo() {
            return `${(this.hovering ? 'logo_saturated' : 'logo')}.png`
        }
    },
    methods: {
        onMouseOver() {
            this.$emit('hover', true)
        },
        onMouseOut() {
            this.$emit('hover', false);
        }
    }
}
</script>

<style>

</style>