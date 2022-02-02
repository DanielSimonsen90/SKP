import { Dispatch, SetStateAction, useState } from 'react';
import { Container, useEffectOnce } from 'danholibraryrjs';
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

export default function ProjectFilter(props: Props) {
    const {
        languageFilter, setLanguageFilter,
        projectFilter, setProjectFilter
    } = props;
    const [shouldStick, setShouldStick] = useState(false);

    function onWindowScroll(e: Event) {
        setShouldStick((e.currentTarget as Window).scrollY > 78);
    }

    useEffectOnce(() => {
        window.addEventListener('scroll', onWindowScroll);
        return () => window.removeEventListener('scroll', onWindowScroll);
    })

    return (
        <Container className={`project-filter ${shouldStick ? 'fixed' : ''}`}>
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