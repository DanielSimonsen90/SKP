import { useState } from 'react';
import { useEffectOnce } from 'danholibraryrjs';
import { useTranslate, useTranslateProgrammingLanguages } from 'providers/LanguageProvider'
import { LanguageFilter } from '.';
import BookmarkList from './BookmarkList'
import ProjectContainer from './ProjectContainer'
import ProjectFilter from './ProjectFilter'
import { useMe } from 'providers/MeProvider';

export type FilterProps = {
    languageFilter: LanguageFilter | string
    projectFilter: string
}

export default function ProjectsContent() {
    const translate = useTranslate();
    const translateLanguage = useTranslateProgrammingLanguages();
    const [languageFilter, setLanguageFilter] = useState<LanguageFilter>(translate('all') as LanguageFilter);
    const [projectFilter, setProjectFilter] = useState(translate('all'));
    const me = useMe();

    useEffectOnce(() => {
        // console.log(window.location);
        const { hash, search } = window.location;

        if (hash) {
            const id = hash.substring(1);
            document.getElementById(id)?.scrollIntoView({ block: 'center' });
        }
        if (search) {
            const query = search.substring(1).split('&').map(v => v.split('=')) as Array<[string, string]>;
            const set = {
                language: setLanguageFilter,
                projectType: setProjectFilter
            }
            query.forEach(([k, v])=> set[k](translateLanguage[v] || v));
        }
    })

    return (
        <div id="projects-page">
            {me.projects.length ? (<>
                <ProjectFilter 
                    setLanguageFilter={setLanguageFilter} 
                    setProjectFilter={setProjectFilter} 
                    projectFilter={projectFilter} 
                    languageFilter={languageFilter} 
                />
                <BookmarkList />
            </>) : null}
            <ProjectContainer 
                projectFilter={projectFilter} 
                languageFilter={languageFilter} 
            />
        </div>
    )
}
