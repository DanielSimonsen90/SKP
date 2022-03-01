import { InputHTMLAttributes } from 'react'
import { useTranslate } from 'providers/LanguageProvider';
import useItemsFor from './hooks/useItemsFor';

export type FilterTypes = 'language' | 'projectType'
type Props = Omit<InputHTMLAttributes<HTMLInputElement>, 'onChange'> & {
    value: string,
    onChange: (v: string) => void;
    type: FilterTypes,
    bold?: boolean
}

export default function FilterInputList({ value, onChange, type, bold = false, ...props }: Props) {
    const translate = useTranslate();
    const values = useItemsFor(type);
    const id = `filter-data-${type}`;
    
    return (
        <label>
            {(bold && <b>{translate(type)}</b>) || <p>{translate(type)}</p>}
            <input type="text" list={id} {...props}
                value={value} onChange={e => onChange(e.target.value)} 
                placeholder={translate('all')}
            />
            <datalist id={id}>
                {values.map(v => <option value={v} key={v}>{v}</option>)}
            </datalist>
        </label>
    )
}
