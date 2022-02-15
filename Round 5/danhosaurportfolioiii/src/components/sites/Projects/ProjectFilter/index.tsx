import { Dispatch, SetStateAction, useEffect, useRef, useState } from 'react';
import { Container, useEffectOnce } from 'danholibraryrjs';
import ToTop from 'components/shared/navigation/ToTop';
import { LanguageFilter } from '..';
import FilterInput from '../FilterInput';
import './ProjectFilter.scss'
import { GetCSSProperty } from 'danholibraryjs';

type SetState = Dispatch<SetStateAction<string>>;
type Props = {
    languageFilter: LanguageFilter
    projectFilter: string,
    setLanguageFilter: SetState
    setProjectFilter: SetState,
}

export default function ProjectFilter(props: Props) {
    const {
        languageFilter, setLanguageFilter,
        projectFilter, setProjectFilter
    } = props;
    const [shouldStick, setShouldStick] = useState(false);
    const className = 'project-filter';

    function onWindowScroll(e: Event) {
        setShouldStick((e.currentTarget as Window).scrollY > 78);
    }

    useEffectOnce(() => {
        window.addEventListener('scroll', onWindowScroll);
        return () => window.removeEventListener('scroll', onWindowScroll);
    })
    useEffect(() => {
        const query = `.${className}`;
        const el = document.querySelector(query);
        if (!el) return;

        const { classList } = el;
        const animationTime = GetCSSProperty('--animation-time', 'number', query);
        let timeout: NodeJS.Timeout;

        if (!shouldStick) {
            classList.add('animation-reverse');
            timeout = setTimeout(() => classList.remove('fixed', 'animation-reverse'), animationTime)
        }
        else classList.add('fixed');

        return () => clearTimeout(timeout);
    }, [shouldStick])

    return (
        <Container className={className}>
            <FilterInput type='language' bold={true}
                value={languageFilter} onChange={setLanguageFilter}
            />
            <FilterInput type='projectType' bold={true}
                value={projectFilter} onChange={setProjectFilter}
            />
            {shouldStick && <ToTop />}
        </Container>
    )
}
