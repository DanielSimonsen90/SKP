import { useEffect, useMemo, useState } from 'react';
import Icon from 'react-fontawesome';
import { Container } from 'danholibraryrjs';

import ToTop from 'components/shared/navigation/ToTop';
import { useTranslateFilters } from 'providers/LanguageProvider';

import { FilterProps } from '../ProjectsContent';
import { useModal } from 'providers/ModalProvider';
import { useMe } from 'providers/MeProvider';
import BookmarkList from '../BookmarkList';
import useWindowScroll from './hooks/useWindowScroll';
import useFilterOptions from './hooks/useFilterOptions';
import useNewFilter from './hooks/useNewFilter';
import './styles/index.scss';
import { useBookmarks } from 'providers/BookmarkProvider';

export default function ProjectFilter({ filter, optionResets, setFilter }: FilterProps) {
    const className = 'project-filter';    
    const shouldStick = useWindowScroll(78, className);
    const translate = useTranslateFilters();
    const me = useMe();
    const [value, setValue] = useState(Object.array(filter).map(([prop, value]) => {
        try { return `${translate[prop].title}:${value}`; }
        catch { return `${prop}:${value}` }
    }).join(' '));
    const internalValue = useMemo(() => value.replaceAll(' ', ':'), [value]);
    const { options, setOptions, onFocus } = useFilterOptions({ value, internalValue, filter, onOptionSelected, onOptionValueSelected })
    const [showing, toggle] = useModal(<BookmarkList onClick={() => toggle('hide')} />);
    const { bookmarks } = useBookmarks();
    const hasBookmarks = useMemo(() => bookmarks.length > 0, [bookmarks]);
    
    useNewFilter(internalValue, setFilter);
    useEffect(() => { setOptions(null) }, [optionResets])
    useEffect(() => { if (!hasBookmarks && showing) toggle('hide') }, [hasBookmarks]);

    return (
        <Container className={className} onClick={e => e.stopPropagation()}>
            <label>
                Filter
                <input type='text' onChange={e => setValue(e.target.value)} value={value}
                    onClick={() => onFocus(true)} /*onBlur={() => onFocus(true)}*/
                />
                {me.projects.length && hasBookmarks && <Icon name="bookmark" className='bookmark bookmark-list' onClick={() => toggle('show')} />}
            </label>
            {options && <div className="options">{options}</div>}
            {shouldStick && <ToTop />}
        </Container>
    )


    function onOptionSelected(title: string) {
        return setValue(v => v ? `${v}${title}:` : `${title}:`);
    }
    function onOptionValueSelected(optionValue: string) {
        return setValue(v => `${v}${optionValue} `);
    }
}
