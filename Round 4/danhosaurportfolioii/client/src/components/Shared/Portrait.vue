<template>
  <div class="image-container">
      <img src="profile_picture.png" alt="Very handsome man">
  </div>
</template>

<script>

export default {

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