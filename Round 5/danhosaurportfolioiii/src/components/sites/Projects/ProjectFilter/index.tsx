import { useEffect, useMemo, useRef, useState } from 'react';
import Icon from 'react-fontawesome';
import { Container, ClickEvent, useEffectOnce } from 'danholibraryrjs';

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
import CloseableInput from './ClosableInput/ClosableInput';

export default function ProjectFilter({ filter, optionResets, setFilter, renderCards, setRenderCards }: FilterProps) {
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
    const [toggle, showing] = useModal(<BookmarkList onClick={() => toggle('hide')} />);
    const { bookmarks } = useBookmarks();
    const hasBookmarks = useMemo(() => bookmarks.length > 0, [bookmarks]);
    
    useNewFilter(internalValue, setFilter);
    useEffect(() => { setOptions(null) }, [optionResets])
    useEffect(() => { if (!hasBookmarks && showing) toggle('hide') }, [hasBookmarks]);

    const onRenderCardsToggleClicked = (e: ClickEvent) => {
        e.preventDefault();
        setRenderCards(!me.projects.length || !renderCards);
    }

    return (
        <Container className={className} onClick={e => e.stopPropagation()}>
            <label>
                Filter
                <CloseableInput setValue={setValue} value={value}
                    onClick={() => onFocus(true)} /*onBlur={() => onFocus(true)}*/
                />
                <Icon name="bookmark" className={`bookmark bookmark-list ${hasBookmarks && me.projects.length ? 'visible' : 'invisible'}`} 
                    onClick={() => toggle('show')} tabIndex={hasBookmarks && me.projects.length ? 0 : -1}
                />
                <Icon name={me.projects.length && renderCards ? 'list' : 'table'} className="render-cards-toggle"
                    onClick={onRenderCardsToggleClicked} tabIndex={0}
                />
            </label>
            {options && <ul className="options">{options}</ul>}
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
