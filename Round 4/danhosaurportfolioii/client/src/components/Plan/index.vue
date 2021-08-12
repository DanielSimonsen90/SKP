<template>
  <div id="plan">
    <table>
      <tr>
        <th>Start</th>
        <th>{{ language.get('end') }}</th>
        <th>{{ language.get('occupation') }}</th>
      </tr>
      <tr :class="`plan-item ${plan.course.split(' ')[0]}`" v-for="(plan, i) in plans" :key="i">
        <td>{{ plan.start }}</td>
        <td>{{ plan.end }}</td>
        <td>{{ plan.course }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
import { Me } from 'danhosaurportfolio-models';
import { locationCollection } from '../../data';

export default {
    props: {
      me: Me,
      language: Map
    },
    data: () => ({
      plans: locationCollection.filter(p => p.start.getTime() > new Date().getTime() || p.end.getTime() > new Date().getTime())
    })
}
</script>

<style lang="scss">
@import '@/scss/variables';
@import '@/scss/partials';
@import '@/scss/mixins';

#plan {
  display: inline-block;
  margin-top: 2.5%;
  width: 90%;
}

table {
  @extend %hoverable-border;
  @extend %shadow-me;

  background-color: $background-secondary;
  font-size: 36px;
  width: 80%;
  margin: 0 auto;

  border-radius: .75rem;
}

th { 
  color: $theme-primary;
  text-decoration: underline;
}

.Skolepraktik {
  @include table-row-hoverable($background-secondary, $theme-tertiary);
}
.Hovedforløb {
  @include table-row-hoverable($background, $theme-secondary);
}

tr {
  @extend %shadow-me;

  margin: 1%;
  padding: 1% 5%;
}

td {
  padding: 1% 0;
}
</style>