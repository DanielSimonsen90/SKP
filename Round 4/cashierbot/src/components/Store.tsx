import React, { useState } from 'react'
import Customer from '../Models/Customer';
import Product from '../Models/Product';
import CashierComponent from './Cashier';
import ProductSelect from './ProductSelect';

function resetCustomer() {
    return new Customer();
}

export default function App() {
    const [resets, setResets] = useState(0);
    const [customer, setCustomer] = useState(resetCustomer());

    function onReset() {
        setResets(pre => pre + 1);
        setCustomer(resetCustomer());
    }

    function onProductAdd(p: Product) {
        console.log(`Added product`, p);
        
        const clone = {...customer} as Customer;
        clone.products.push(p);
        setCustomer(clone);
    }

    return (
        <div id="store">
            <ProductSelect resets={resets} onProductSelected={onProductAdd} />
            <CashierComponent customer={customer} onReset={onReset} />
        </div>
    )
}
