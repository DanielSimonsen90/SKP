<template>
  <div id="logo-container" :style="containerStyle">
    <img id="logo" :src="logo"
        @mouseover="onMouseOver" 
        @mouseout="onMouseOut"
        @click="onLogoClicked"
    >
  </div>
</template>

<script>
/**@props { hovering: Boolean }
 * @emits hover(hovering: boolean), click(e: ClickEvent)*/
export default {
    props: {
        hovering: Boolean,
        height: Number,
        width: Number
    },
    computed: {
        logo() {
            return `logos/${(this.hovering ? 'saturated' : 'default')}.png`
        },
        containerStyle(_this) {
            const height = `${_this.height}%`;
            const width = `${_this.width}%`;

            return { height, width }
        }
    },
    methods: {
        onMouseOver() {
            this.$emit('hover', true)
        },
        onMouseOut() {
            this.$emit('hover', false);
        },
        onLogoClicked(e) {
            this.$emit('click', e)
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
#logo-container {
    display: inline-block;
    max-width: fit-content;
}

#logo {
    @extend %clickable;
    
    height: inherit;
    width: inherit;

    max-width: auto;
    max-height: 100%;
}
</style>