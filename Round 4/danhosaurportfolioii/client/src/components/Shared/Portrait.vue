<template>
  <div class="image-container">
      <img src="profile_picture.png" alt="Very handsome man" @click="onPFPClick">
  </div>
</template>

<script>

/**@emits click(e: MouseClickEvent)*/
export default {
    methods: {
        onPFPClick(e) {
            this.$emit('click', e)
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/partials';
@import '@/scss/variables';

.image-container {
    @extend %hoverable-border;
    @extend %hoverable-background;

    display: inline-block;
    position: absolute;

    width: 80%;
    border-radius: 100%;

    background: darken($color-hoverable, 27%);
    border-color: darken($theme-primary, $theme-difference * 1.5);

    &:hover {
        background: darken($color-hover, 27% * 3);
        border-color: darken($theme-secondary, $theme-difference * 1.5);
    }

    img {
        position: relative;
        width: 100%;
        height: 100%;
        border-radius: inherit;
    }
}

</style>