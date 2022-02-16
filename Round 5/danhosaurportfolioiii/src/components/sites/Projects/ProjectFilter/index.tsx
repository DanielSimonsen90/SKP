import { Dispatch, SetStateAction, useEffect, useState } from 'react';
import { Container, useAnimationReverse, useEffectOnce, useEventListener } from 'danholibraryrjs';
import { GetCSSProperty } from 'danholibraryjs';
import ToTop from 'components/shared/navigation/ToTop';
import { LanguageFilter } from '..';
import FilterInput from '../FilterInput';
import './ProjectFilter.scss'

type SetState = Dispatch<SetStateAction<string>>;
type Props = {
    languageFilter: LanguageFilter
    projectFilter: string,
    setLanguageFilter: SetState
    setProjectFilter: SetState,
}

function useWindowScroll(stick: number, className: string) {
    const [shouldStick, setShouldStick] = useState(false);
    useEventListener('scroll', e => setShouldStick((e.currentTarget as Window).scrollY > stick), window);
    const query = `.${className}`;
    const animateReverse = useAnimationReverse(query, 'animation-reverse', 
        GetCSSProperty('--animation-time', 'number', 
            document.querySelector(query) ? 
                query : 
                undefined
            )
        );

    useEffect(() => {
        const el = document.querySelector(query);
        if (!el) return;

        if (!shouldStick) animateReverse({ className: 'fixed' });
        else el.classList.add('fixed');
    }, [shouldStick])

    return shouldStick;
}

export default function ProjectFilter(props: Props) {
    const {
        languageFilter, setLanguageFilter,
        projectFilter, setProjectFilter
    } = props;
    const className = 'project-filter';
    const shouldStick = useWindowScroll(78, className);

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
