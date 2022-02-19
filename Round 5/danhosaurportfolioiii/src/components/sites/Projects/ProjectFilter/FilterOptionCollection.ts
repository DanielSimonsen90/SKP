import { Component } from "danholibraryrjs";

export type FilterOption = {
    key: string,
    option: Component,
    component: Component,
}

export default class FilterOptionCollection {
    constructor(public items: Array<FilterOption>) {}

    private getProperty<Key extends keyof FilterOption>(property: Key) {
        return this.items.map(o => o[property]);
    }
    public get keys() { return this.getProperty('key') }
    public get options() { return this.getProperty('option') }
    public get components() { return this.getProperty('component') }
}