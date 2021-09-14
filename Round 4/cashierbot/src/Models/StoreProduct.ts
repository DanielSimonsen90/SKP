import Product from './Product';

export default class StoreProduct extends Product {
    constructor(name: string, price: number, 
        public stock: number
    ) {
        super(name, 0, price);
    }

    public get available() {
        return this.stock > 0;
    }
}