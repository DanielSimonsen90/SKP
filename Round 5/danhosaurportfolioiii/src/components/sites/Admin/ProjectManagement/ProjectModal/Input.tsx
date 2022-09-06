import { HTMLInputTypeAttribute } from "react";
import { UseStateSetState } from "danholibraryrjs";

export type LabelState = string | number | boolean | Date;
export type InputProps<S extends LabelState, T extends HTMLInputTypeAttribute> = {
    title: string,
    type: T,
    placeholder?: string,
    value: S,
    onChange: UseStateSetState<S>
    required?: boolean,
}

export default function Label<
    S extends LabelState, 
    T extends HTMLInputTypeAttribute
>({ title, type, value, onChange, placeholder, required = false }: InputProps<S, T>) {
    const inputValue = (
        typeof value === 'boolean' ? "" : 
        value instanceof Date ? value.toString() : 
        value as number
    );
    const inputChecked = typeof value === 'boolean' ? value : null;

    return (
        <label>
            <p>{title}</p>
            <input type={type} required={required}
                value={inputValue} checked={inputChecked ?? false} placeholder={placeholder}
                onChange={e => onChange((e.currentTarget.value || e.currentTarget.checked) as S)}
                onKeyDown={e => {
                    if (type === 'checkbox' && (e.key === 'Enter' || e.key === 'NumpadEnter')) {
                        e.preventDefault();
                        e.stopPropagation();
                        onChange(true as S);
                    }
                }}
            />
        </label>
    )
}