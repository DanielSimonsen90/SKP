export default class Product {
    constructor(
        public name: string, 
        public amount: number,
        public price: number
    ) {

    }

    public get scannable() {
        return Math.random();
    }
}