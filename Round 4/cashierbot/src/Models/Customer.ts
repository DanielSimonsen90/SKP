import Product from "./Product";
import { Wait } from './Util';

export default class Customer {
    constructor (
        private _moneys = 1000,
        public products: Array<Product> = []
    ) {

    }

    public async pay(price: number) {
        return Wait(10).then(() => this._moneys > price);
    }
}