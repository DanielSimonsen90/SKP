<template>
  <fieldset :id="id">
      <legend>{{ data.title }}</legend>
      <content class="article-content">
          <div v-for="({ name, description }, i) in data.content" :key="i">
              <h3 :id="`${id}-name-${i}`" :class="`${id}-name`">{{ name }}</h3>
              <p :id="`${id}-description-${i}`" :class="`${id}-description article-sentence`">{{ description }}</p>
          </div>
      </content>
  </fieldset>
</template>

<script>

/**@props { data: { title: string, content: Array<Item> } }*/
export default {
    name: 'sparetime',
    props: {
        data: {
            title: String,
            content: Array
        }
    },
    data: () => ({
        id: 'sparetime'
    })
}
</script>

<style lang="scss">
@import '@/scss/mixins';
@import '@/scss/variables';

#sparetime {
    // width: 25%;
    // right: 17.5%;

    grid-column: 2;
    grid-row: 1;
}

.sparetime-name {
    @include margin-block(0, 0);
    color: $theme-secondary;
    text-decoration: underline;
    display: inline;
    margin-left: 2%;
}
.sparetime-description {
    @include margin-block(1%, 1);
    margin-left: 2%;
}
</style>