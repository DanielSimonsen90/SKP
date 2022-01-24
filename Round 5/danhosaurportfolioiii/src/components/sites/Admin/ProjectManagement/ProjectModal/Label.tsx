import { HTMLInputTypeAttribute } from "react";
import { UseStateSetState } from "danholibraryrjs";

export type LabelState = string | number | boolean | Date;
export type InputProps<S extends LabelState, T extends HTMLInputTypeAttribute> = {
    title: string,
    type: T,
    value: S,
    onChange: UseStateSetState<S>
}

export default function Label<
    S extends LabelState, 
    T extends HTMLInputTypeAttribute
>({ title, type, value, onChange }: InputProps<S, T>) {
    const inputValue = (
        typeof value === 'boolean' ? "" : 
        value instanceof Date ? value.toString() : 
        value as number
    );
    const inputChecked = typeof value === 'boolean' ? value : null;

    return (
        <label>
            <p>{title}</p>
            <input type={type}
                value={inputValue}
                checked={inputChecked}
                onChange={e => onChange((e.currentTarget.value || e.currentTarget.checked) as S)} 
            />
        </label>
    )
}