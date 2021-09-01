import { Login, Post, User } from "models";

export default class LocalStorage {
    /**
     * @typedef SavedItems
     * @type {Login | User | Post}
     * @param {{ new(): SavedItems }} type 
     * @param {string} key 
     * @returns {SavedItems[]}
     */
    static getItems(type, key) {
        /**@type {SavedItems[] | [] } */
        const items = JSON.parse(localStorage.getItem(key)) || [];
        return items.map(i => ({...new type(), ...i }))
    }
    /**
     * @param {{ new(): SavedItems }} type 
     * @param {string} key 
     * @returns {SavedItems}
     */
    static getItem(type, key) {
        if (localStorage.getItem(key)) return {...new type(), ...JSON.parse(localStorage.getItem(key)) };
    }
}