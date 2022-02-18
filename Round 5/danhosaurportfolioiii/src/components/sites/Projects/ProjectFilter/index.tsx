import { useEffect, useState } from 'react';
import { Container, useClickOutside } from 'danholibraryrjs';

import ToTop from 'components/shared/navigation/ToTop';
import { useTranslateFilters } from 'providers/LanguageProvider';

import { FilterProps } from '../ProjectsContent';
import useWindowScroll from './hooks/useWindowScroll';
import useFilterOptions from './hooks/useFilterOptions';
import useNewFilter from './hooks/useNewFilter';
import './ProjectFilter.scss'


export default function ProjectFilter({ filter, setFilter }: FilterProps) {
    const className = 'project-filter';    
    const shouldStick = useWindowScroll(78, className);
    const translate = useTranslateFilters();
    const [value, setValue] = useState(Object.array(filter).map(([prop, value]) => `${translate[prop]['title']}:${value}`).join(' '));
    const { options, setFilterOptions, onFocus } = useFilterOptions({ value, filter, onOptionSelected, onOptionValueSelected })
    
    useClickOutside(`.${className}`, () => setFilterOptions(null));
    useNewFilter(value, setFilter);

    return (
        <Container className={className}>
            <label>
                Filter
                <input type='text' onChange={e => setValue(e.target.value)} value={value}
                    onClick={() => onFocus(true)} onBlur={() => onFocus(false)} 
                />
            </label>
            {options && <div className="options">{options}</div>}
            {shouldStick && <ToTop />}
        </Container>
    )


    function onOptionSelected(title: string) {
        console.log(title);
        return setValue(v => v ? `${v}${title}:` : `${title}:`);
    }
    function onOptionValueSelected(optionValue: string) {
        return setValue(v => `${v}${optionValue} `);
    }
}
