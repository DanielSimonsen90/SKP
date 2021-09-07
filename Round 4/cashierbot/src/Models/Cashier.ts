import Product from "./Product";
import Scanner from "./Scanner";
import { Wait } from "./Util";

export default class Cashier {
    constructor (private _scanner: Scanner) {}

    public getGreeting() {
        const hours = new Date().getHours();

        return `Good ${(() => {
            if (hours < 10) return 'morning';
            else if (hours < 16) return 'afternoon';
            return 'evening'
        })()}`;
    }

    public async scanFromBook(product: Product) {
        await Wait(10);
        return product.price;
    }
    public async getPrice(type: 'scan' | 'book', product: Product) {
        return (
            type === 'scan' && 
            this._scanner.scan(product) && product.price
        ) || this.scanFromBook(product);
    }
}