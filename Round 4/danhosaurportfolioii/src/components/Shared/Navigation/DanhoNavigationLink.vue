<template>
    <li class="link-item" :title="_tooltip"
        @click="onLinkClicked(link)"
    >{{ link }}</li>
</template>

<script>
/**@props { link: string, title: string } 
 * @emits click(link: string)*/
export default {
    props: {
        link: String,
        tooltip: String
    },
    computed: {
        _tooltip: (_this) => _this.title || _this.link 
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

    display: inline-block;
    margin-left: $link-item-margin;
    margin-right: $link-item-margin;

    &:hover {
      text-decoration: underline;
      transition: $transition-hover / 2;
    }
}
</style>