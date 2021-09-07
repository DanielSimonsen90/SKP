import React from 'react'
import Product from '../Models/Product'
import ProductComponent from './Product'

interface Props {
    products: Array<Product>
}

export default function ScanProducts({ products }: Props) {
    return (
        <div className="scan-items">
            {products.map(p => (
                <ProductComponent value={p} clickable={false} key={p.name} />
            ))}
        </div>
    )
}
