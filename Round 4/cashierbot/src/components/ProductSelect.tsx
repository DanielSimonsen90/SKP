import React, { useState } from 'react'
import Product from '../Models/Product';
import StoreProduct from '../Models/StoreProduct';
import StoreProductComponent from './StoreProduct';

function resetProducts() {
    return new Array<StoreProduct>(
        new StoreProduct('Chicken Noodles', 5, 20),
        new StoreProduct('Coca Cola', 15, 6),
        new StoreProduct('Buns', 12, 6),
    )
}

interface Props {
    resets: number,
    onProductSelected: (product: Product) => void
}

export default function ProductSelect({ resets, onProductSelected }: Props) {
    const [products, setProducts] = useState(resetProducts());

    function onSelected(p: StoreProduct | undefined) {
        if (!p || !p.available) return;

        const copy = [...products];
        const pIndex = products.indexOf(p);
        p.stock =- 1;
        copy[pIndex] = p;
        const { amount, price, name } = p;

        setProducts(copy);
        onProductSelected(new Product(name, amount, price));
    }

    return (
        <div data-resets={resets}>
            {products.map(p => (
                <StoreProductComponent value={p} 
                    onSelected={p => onSelected(products.find(_p => _p.name === p.name))} 
                    clickable={true} key={p.name} 
                />
            ))}
        </div>
    )
}
