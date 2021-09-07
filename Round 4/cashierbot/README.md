# Cashiers are just bots man

## Models
### Product
```ts
interface IProuduct {
    name: string
    amount: number
    price: number
    get scannable: boolean
}
```

### Customer
```ts
interface ICustomer {
    products: Product[]
    moneys: number

    pay(price: number): Promise<boolean>
}
```

### StoreProduct 
```ts
interface IStoreProduct extends IProduct {
    quantity: number
    get available: boolean
}

```

### Scanner
```ts
interface IScanner {
    private history: Product[]

    scan(product: Product): Promise<boolean>
    total(): number
}
```

### Cashier
```ts
interface ICashier {
    private scanner: Scanner
    
    run(customers: Customer[], plsPay: (price: number) => Promise<boolean>): Promise<void>
    getPrice(type: 'scan' | 'book', product: Product): Promise<void>
    getReciept(): string
}
```

## Components
### App => Store
```tsx
export default function Store() {
    const [resets, setResets] = useState(0);
    const [customer, setCustomer] = useState(resetCustomer());

    function onReset() {
        setStoreProducts(resetProducts())
        setProducts([]);
    }

    function onProductAdd(p) {
        setCustomer(customer => {
            const clone = { ...customer };
            clone.products.push(p);
            return clone;
        })
    }

    return (
        <div id="store">
            <ProductSelect resets={resets} onProductSelected={onProductAdd} />
            <Cashier customer={customer} onReset={onReset} />
        </div>
    )
}
```

### ProductSelect
```tsx
export default function ProductSelect({ resets, onProductSelected }) {
    const [products, setProducts] = useState(resetProducts());
    
    function onSelected(p) {
        if (!p.available) return;

        const copy = [...products];
        const pIndex = products.indexOf(p);
        p.quantity--;
        copy[pIndex] = p;

        setProducts(copy);
        onProductSelected(p);
    }

    return (
        <>
            {products.map(p => (
                <Product value={p} onSelected={onSelected} clickable={true} key={p.name}>
            ))}
        </>
    )
}
```

### Product
```tsx
export default function Product({ value, onSelected, clickable }) {
    const { name, quantity, price } = value;

    return (
        <div name={name} onClick={() => clickable && onSelected(value)}>
            <h4>{name}</h4>
            <h6>{price}</h6>
            <p>{quantity}</p>
        </div>
    )
}
```

### Cashier
```tsx
export default function Cashier({ customer, onReset }) {
    const cashier = new Cashier();
    const [running, setRunning] = useState(false);
    const [scanned, setScanned] = useState(Array<Product>);
    const [scanCompleted, setScanCompleted] = useState(false);
    const [reciept, setReciept] = useState("");

    function onPay() {
        if (confirm('Would you like the reciept?')) {
            setReciept(cashier.getReciept());
            return setTimeout(() => {
                setReciept('');
                onReset();
            }, 10 * 1000);
        }

        return onReset();
    }

    if (!running) return <button onClick={() => setRunning(true)}>Go to cashier</button>
    else if (reciept) return <div>{reciept}</div>

    return (
        <div class="scan-items" scanned="false">
            {customer.products.filter(p => scanned.some(_p => _p.name != p.name)).map(p => (
                <Product value={p} clickable={false} key={p.name} />
            ))}
        </div>
        <button disabled={!scanComplete} onClick={() => onPay()}>{scanComplete ? 'Pay pls' : 'Scanning...'}</button>
        <div class="scan-items" scanned="true">
            {customer.products.filter(p => scanned.some(_p => _p.name == p.name)).map(p => (
                <Product value={p} clickable={false} key={p.name} />
            ))}
        </div>
    )
}
```
