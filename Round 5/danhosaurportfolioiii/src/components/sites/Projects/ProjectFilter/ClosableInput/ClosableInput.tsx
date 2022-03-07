import Icon from 'react-fontawesome';
import { BaseProps } from 'danholibraryrjs';
import './ClosableInput.scss';
import { useState } from 'react';
import { BetterOmit } from 'danholibraryjs';

type Props = BetterOmit<BaseProps<HTMLInputElement>, 'onChange'> & {
    value: string,
    setValue(value: string): void
};

export default function CloseableInput({ value, setValue, ...props }: Props) {
    return (
        <div className="closable-input">
            <input type="text" {...props} value={value} onChange={e => setValue(e.target.value)} />
            <Icon name="times" className={`icon close${value ? ' visible' : ' invisible'}`} 
                onClick={() => setValue("")} tabIndex={value ? 0 : -1} 
            />
        </div>
    )
}