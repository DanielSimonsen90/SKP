import Product from "./Product";
import { Wait } from "./Util";

export default class Scanner {
    constructor(private _history: Array<Product>) {

    }
    
    public async scan(product: Product) {
        this._history.push(product);
        const time = 1;
        await Wait(product.scannable ? time : time * 10);
        return true;
    }
}