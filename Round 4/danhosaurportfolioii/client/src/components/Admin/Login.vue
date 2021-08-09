<template>
  <fieldset id="admin-login">
      <legend>Admin Login</legend>
      <input id="admin-username" type="text">
      <button @click="onSubmit">Login</button>
  </fieldset>
</template>

<script>
export default {
    methods: {
        onSubmit() {
            const adminUsername = document.getElementById('admin-username');
        }
    }
}
</script>

<style>

</style>