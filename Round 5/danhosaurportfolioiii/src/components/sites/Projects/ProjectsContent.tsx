import { useState } from 'react';
import { PlanLocation, ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useEffectOnce, UseStateSetState, useLocalStorage } from 'danholibraryrjs';

import { useTranslateProgrammingLanguages } from 'providers/LanguageProvider'
import { useMe } from 'providers/MeProvider';

import ProjectContainer from './ProjectContainer'
import ProjectFilter from './ProjectFilter'

export type FilterProps = {
    filter: FilterData,
    setFilter: UseStateSetState<FilterData>,
    optionResets: number,
    renderCards: boolean,
    setRenderCards: UseStateSetState<boolean>
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
    const [filter, setFilter] = useState<FilterData>({});
    const [optionResets, setOptionResets] = useState(0);
    const [renderCards, setRenderCards] = useLocalStorage('prefer-cards', false);

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
        <div id="projects-page" onClick={() => setOptionResets(v => v + 1)}>
            {me.projects.length ? <ProjectFilter {...{ renderCards, setRenderCards, filter, setFilter, optionResets }} /> : null}
            <ProjectContainer allowCrud={false} renderCards={renderCards} filter={filter} />
        </div>
    )
}
