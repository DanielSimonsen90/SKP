import { useMemo } from 'react';
import { Project } from 'danhosaurportfolio-models';
import { useEffectOnce } from 'danholibraryrjs';
import { Extensions } from 'danholibraryjs';
import { useMe, useSetProjects } from 'providers/MeProvider';
import { useTranslate } from 'providers/LanguageProvider';
import ProjectComponent from '../Project';
import { FilterProps } from '../ProjectsContent';
import ProjectCard from '../../Admin/ProjectManagement/ProjectCard';
import './ProjectContainer.scss';

type Props = Partial<FilterProps> & {
    renderCards?: boolean,
    onProjectUpdate?: (project: Project) => void,
    onProjectDelete?: (project: Project) => void,
}

export default function ProjectContainer({ 
    filter, setFilter,
    renderCards = false, onProjectUpdate, onProjectDelete
}: Props) {
    const me = useMe();
    const setProjects = useSetProjects();
    const translate = useTranslate();
    const all = translate('all');
    
    const projects = useMemo(() => me.projects
        .filter(p => !Object.array(filter).length || Object.array(filter).every(([prop, value]) => p[prop] === value))
        .filter(p => renderCards || p.display)
        .reverse(), 
    [filter, me, me.projects])

    useEffectOnce(() => { if (!me.projects.length) setProjects(); })

    return (
        <div className={`project-container${!projects.length ? ' no-projects' : ''}`} data-render-cards={renderCards}>
            {(projects.length && projects.map(p => 
                !renderCards ? 
                    <ProjectComponent project={p} key={`${p.name}_${p._id}`} /> :
                    <ProjectCard project={p} key={`${p.name}_${p._id}`} 
                        onUpdate={onProjectUpdate} onDelete={onProjectDelete}
                    />
                )) || <h1>{me.projects.length ? translate('noProjects') : translate('unableToFetch')}</h1>
            }
        </div>
    )
}
