import React from 'react'
import Product from '../Models/Product'

interface Props {
    value: Product,
    clickable: boolean
    onSelected?: (product: Product) => void,
}
export default function ProductComponent({ value, onSelected, clickable }: Props) {
    const { name, amount, price } = value;

    return (
        <div className="product" key={name} onClick={() => clickable && onSelected?.(value)}>
            <h3>{name}</h3>
            <h4 title="Price">{price}</h4>
            <p title="Amount">{amount}</p>
        </div>
    )
}
