import { useState } from 'react';
import { PlanLocation, ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useEffectOnce, UseStateSetState } from 'danholibraryrjs';
import { useTranslate, useTranslateProgrammingLanguages } from 'providers/LanguageProvider'
import { LanguageFilter } from '.';
import BookmarkList from './BookmarkList'
import ProjectContainer from './ProjectContainer'
import ProjectFilter from './ProjectFilter'
import { useMe } from 'providers/MeProvider';

export type FilterProps = {
    filter: FilterData,
    setFilter: UseStateSetState<FilterData>
}
export type FilterData = {
    name?: string,
    language?: ProgrammingLanguage,
    projectType?: string,
    before?: Date,
    after?: Date,
    occupation?: PlanLocation
}

export default function ProjectsContent() {
    const translateLanguage = useTranslateProgrammingLanguages();
    const me = useMe();
    const [filter, setFilter] = useState<FilterData>({})

    useEffectOnce(() => {
        const { hash, search } = window.location;

        if (hash) {
            const id = hash.substring(1);
            document.getElementById(id)?.scrollIntoView({ block: 'center' });
        }
        if (search) {
            const queryData = search.substring(1).split('&').map(v => v.split('=')).reduce((obj, [prop, value]) => {
                obj[prop] = translateLanguage[value] || value;
                return obj;
            }, {} as FilterData);
            setFilter(filter => ({ ...filter, ...queryData }))
        }
    })

    return (
        <div id="projects-page">
            {me.projects.length ? (<>
                <ProjectFilter filter={filter} setFilter={setFilter} />
                <BookmarkList />
            </>) : null}
            <ProjectContainer filter={filter} />
        </div>
    )
}
