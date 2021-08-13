<template>
    <li class="link-item" :title="_tooltip"
        @click="onLinkClicked(link)"
    >{{ link }}</li>
</template>

<script>
/**@props { link: string, tooltip: string } 
 * @emits click(link: string)*/
export default {
    props: {
        link: String,
        tooltip: String
    },
    computed: {
        _tooltip: (_this) => _this.tooltip || _this.link 
    },
    methods: {
        onLinkClicked() {
            this.$emit('click', this.link);
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/variables';

.link-item {
    @extend %clickable;
    @extend %rounded;
    @extend %shadow-me;
    @extend %hoverable-color;

    display: inline-block;
    margin: auto $link-item-margin;
    min-height: 25px;
    min-width: 50px;

    &:hover {
      text-decoration: underline;
      transition: $transition-hover / 2;
    }
}

content:not(footer > content) .link-item {
    @extend %click-me;
    box-shadow: unset;
}
</style>