import React, { useEffect, useState } from 'react'
import ScanProducts from './ScanProducts';
import { Customer, Product, Cashier, Scanner, Wait } from '../Models';

const cashier = new Cashier(new Scanner([]));

interface Props {
    customer: Customer,
    onReset: () => void
}

export default function CashierComponent({ customer, onReset }: Props) {
    const [running, setRunning] = useState(false);
    const [scanned, setScanned] = useState(new Array<Product>());
    const [scanCompleted, setScanCompleted] = useState(false);
    const [reciept, setReciept] = useState('');
    const [total, setTotal] = useState(0);

    function reset() {
        setRunning(false);
        setScanned([]);
        setScanCompleted(false);
        setReciept('')
        setTotal(0);

        onReset();
    }

    function onPay() {
        const paying = window.confirm(`The total is ${total}kr`);

        if (paying) customer.pay(total).then(paid => {
            if (!paid) return onReset();

            if (window.confirm('Would you like the reciept?')) {
                const _reciept = scanned.map(({ name, amount, price }) => 
                    `${amount}x ${name}: ${price * amount}`
                ).join('\n');

                setReciept(_reciept);
            
                return Wait(10).then(() => reset());
            }
    
            return reset();
        })
    }

    useEffect(() => {
        if (!running) return;

        alert(cashier.getGreeting());
        console.log(customer.products);
        

        new Promise<number>(async (resolve, reject) => {
            let total = 0;
            for (const p of customer.products) {
                console.log(`Scanning ${p.name}`);
                
                total += await ((p.scannable && cashier.getPrice('scan', p)) || cashier.scanFromBook(p))
                setScanned(pre => [...pre, p])
            }

            setScanCompleted(true);
            setTotal(total);
            resolve(total);
        })

    }, [customer.products, running])

    if (!running) return <button onClick={() => setRunning(true)}>Go to cashier</button>
    else if (reciept) return <div>{reciept}</div>

    return (
        <>
            <ScanProducts data-scanned="false" products={customer.products.filter(p => scanned.some(_p => _p.name !== p.name))} />
            <button disabled={!scanCompleted} onClick={() => onPay()}>{scanCompleted ? 'Pay pls' : 'Scanning...'}</button>
            <ScanProducts data-scanned="true" products={customer.products.filter(p => scanned.some(_p => _p.name === p.name))} />
        </>
    )
}
