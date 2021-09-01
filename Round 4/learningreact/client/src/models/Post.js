import User from './User';

export default class Post {
    /**
     * @param {string} authorName 
     * @param {string} content 
     */
    constructor(authorName, content) {
        this.authorName = authorName;
        this.content = content;
    }

    get author() {
        return User.users.find(u => u.username == this.authorName);
    }
}