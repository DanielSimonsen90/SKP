import { useMemo } from 'react'
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';

export type FilterTypes = 'language' | 'projectType'
type Props = {
    value: string,
    onChange: (v: string) => void;
    type: FilterTypes,
    bold?: boolean
}

export default function FilterLabel({ value, onChange, type, bold = false }: Props) {
    const translate = useTranslate();
    const { projects } = useMe();

    const values = useMemo(() => projects.reduce((result, acc) => {
        if (!result.includes(acc[type]) && acc.display) result.push(acc[type]);
        return result;
    }, new Array<string>()).map(v => (
        <option value={v} key={v} />
    )), [projects]);
    const id = `filter-data-${type}`;
    
    return (
        <label>
            {(bold && <b>{translate(type)}</b>) || <p>{translate(type)}</p>}
            <input type="text" list={id} 
                value={value} onChange={e => onChange(e.target.value)} 
                placeholder={translate('all')}
            />
            <datalist id={id}>
                {values}
            </datalist>
        </label>
    )
}
