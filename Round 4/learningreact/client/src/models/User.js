import Post from "./Post";
import LocalStorage from "./Util/LocalStorage";
import Images from "./Util/Images";

export default class User {
    /**@returns {User[]}*/
    static get users() {
        return LocalStorage.getItems(User, 'users')
    }
    /**@returns {User}*/
    static get client() {
        return LocalStorage.getItem(User, 'user');
    }

    /**@param {string} username */
    constructor(username) {
        this.avatar = Images.avatars['default'];
        this.banner = Images.banners['default'];
        this.bio = "I'm a new user!";
        this.username = username;
    }

    /**@returns {Post[]} */
    get posts() {
        return LocalStorage.getItems(Post, 'posts');
    }
}