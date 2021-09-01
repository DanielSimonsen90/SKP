import LocalStorage from "./Util/LocalStorage";

export default class Login {
    /**@returns {Login[]}*/
    static get logins() {
        return LocalStorage.getItems(Login, 'logins');
    }

    /**@param {string} username @param {string} password*/
    constructor(username, password) {
        this.username = username;
        this.password = password;
    }
}