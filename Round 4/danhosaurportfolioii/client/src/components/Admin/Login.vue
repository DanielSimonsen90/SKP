<template>
  <fieldset id="admin-login">
      <legend>Admin Login</legend>
      <input id="admin-username" type="text" @keypress="onTextChanged">
      <button id="login-button" @click="onSubmit" disabled>Login</button>
  </fieldset>
</template>

<script>
import { API } from '../../data';

/**@emits admin-login(admin: { username: string, _id: number }) */
export default {
    name: 'admin-login',
    mounted() {
        const input = document.getElementById('admin-username');
        input.onkeypress = (e) => {
            if (e.key == 'Enter') this.onSubmit();
        }
    },
    methods: {
        async onSubmit() {
            const loginButton = document.getElementById('login-button');
            loginButton.textContent = 'Logging in...'
            const adminUsernameElement = document.getElementById('admin-username');
            const adminUsername = adminUsernameElement.value;
            let admins = await API.getAdmins();

            if (!admins || !admins.length) {
                return console.error('Admins unable to be fetched - aborting admin login request.');
            }

            const admin = admins.find(a => a.username == adminUsername);
            if (!admin) {
                alert('Invalid admin login.');
                loginButton.textContent = 'Login';
                adminUsernameElement.value = '';
                return adminUsernameElement.focus();
            }

            this.$emit('admin-login', admin);
        },
        onTextChanged({ target }) {
            const loginButton = document.getElementById('login-button');
            if (loginButton.disabled && target.value || !loginButton.disabled && !target.value) {
                loginButton.toggleAttribute('disabled')
            }
        }
    }
}
</script>

<style lang="scss">
@import '@/scss/mixins';
@import '@/scss/variables';

#admin-login {
    position: fixed;
    transform: translate(-50%, -50%);
    @include tblr(45%, unset, 50%, unset);
    @include height-width(23%, 25%);

    display: flex;
    flex-direction: column;
    font-size: 36px;

    > * {
        font-size: inherit;
        text-align: center;
    }

    button {
        position: relative;
        @include tblr(unset, -25%, 5%, 0);
        margin: 1%;
        width: 90%;

        &[disabled=disabled] {
            background-color: lighten($background-secondary, $theme-difference / 1);

            &:hover {
                background-color: unset;
            }
        }
    }
}

#admin-username {
    position: relative;
    top: 5%;
}
</style>