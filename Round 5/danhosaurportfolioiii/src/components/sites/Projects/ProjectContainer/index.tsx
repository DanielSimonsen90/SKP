import { useMemo } from 'react';
import { PlanLocation, Project } from 'danhosaurportfolio-models';
import { classNames, useEffectOnce } from 'danholibraryrjs';

import { useMe, useSetProjects } from 'providers/MeProvider';
import { useTranslate } from 'providers/LanguageProvider';

import ProjectComponent from '../Project';
import { FilterProps } from '../ProjectsContent';
import ProjectCard from '../Project/ProjectCard';

import './ProjectContainer.scss';

type Props = Partial<FilterProps> & {
    allowCrud: boolean,
    onProjectUpdate?: (project: Project) => void,
    onProjectDelete?: (project: Project) => void,
}

export default function ProjectContainer({ 
    filter, allowCrud, renderCards, 
    onProjectUpdate, onProjectDelete
}: Props) {
    const me = useMe();
    const setProjects = useSetProjects();
    const translate = useTranslate();
    
    const projects = useMemo(() => me.projects
        .filter(p => (
            !filter ||
            !Object.array(filter).length || 
            Object.array(filter).every(([prop, value]) => (
                // @ts-ignore
                p[prop] === value || 
                (prop === 'occupation' && me.projects.locations.get(value as PlanLocation)?.includes(p)) ||
                (prop === 'before' && value instanceof Date && p.createdAt.getTime() <= value.getTime()) ||
                (prop === 'after' && value instanceof Date && p.createdAt.getTime() >= value.getTime())
            )))
        )
        .filter(p => {
            if (p._id === null) console.warn(`Project doesn't have an id`, p);
            return allowCrud || p.display
        })
        .reverse(), 
    [filter, me, me.projects]);

    useEffectOnce(() => { if (!me.projects.length) setProjects(); });

    return (
        <section className={classNames('project-container', !projects.length ? 'no-projects' : undefined)} 
            data-render-cards={renderCards} 
        >
            {(projects.length && projects.map(p => 
                !renderCards ? 
                    <ProjectComponent project={p} key={`${p.name}_${p._id}`} /> :
                    onProjectUpdate && onProjectDelete && 
                        <ProjectCard project={p} key={`${p.name}_${p._id}`} allowCrud={allowCrud}
                            onUpdate={onProjectUpdate} onDelete={onProjectDelete}
                        />
                )) || <h1>{translate(me.projects.length ? 'noProjects' : 'unableToFetch')}</h1>
            }
        </section>
    )
}
