import { InputHTMLAttributes, useMemo } from 'react'
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';

export type FilterTypes = 'language' | 'projectType'
type Props = Omit<InputHTMLAttributes<HTMLInputElement>, 'onChange'> & {
    value: string,
    onChange: (v: string) => void;
    type: FilterTypes,
    bold?: boolean
}

export default function FilterInput({ value, onChange, type, bold = false, ...props }: Props) {
    const translate = useTranslate();
    const { projects } = useMe();

    const values = useMemo(() => projects.reduce((result, acc) => {
        if (!result.includes(acc[type]) && acc.display) result.push(acc[type]);
        return result;
    }, new Array<string>()).sort().map(v => (
        <option value={v} key={v} />
    )), [projects]);
    const id = `filter-data-${type}`;
    
    return (
        <label>
            {(bold && <b>{translate(type)}</b>) || <p>{translate(type)}</p>}
            <input type="text" list={id} {...props}
                value={value} onChange={e => onChange(e.target.value)} 
                placeholder={translate('all')}
            />
            <datalist id={id}>
                {values}
            </datalist>
        </label>
    )
}
