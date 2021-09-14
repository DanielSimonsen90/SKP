import React from 'react'
import StoreProduct from '../Models/StoreProduct'

interface Props {
    value: StoreProduct,
    clickable: boolean
    onSelected?: (product: StoreProduct) => void,
}
export default function ProductComponent({ value, onSelected, clickable }: Props) {
    const { name, stock, price } = value;

    return (
        <div className="product" key={name} onClick={() => clickable && onSelected?.(value)}>
            <h3 title={`Ya wanna buy sum ${name.toLowerCase()}?`}>{name}</h3>
            <h4 title="Price">{price}</h4>
            <p title="Stock">{stock}</p>
        </div>
    )
}
