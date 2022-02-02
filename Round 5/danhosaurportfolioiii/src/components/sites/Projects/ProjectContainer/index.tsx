import { useMemo } from 'react';
import { Project } from 'danhosaurportfolio-models';
import { useEffectOnce } from 'danholibraryrjs';
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
    languageFilter = '', projectFilter = '', 
    renderCards = false, onProjectUpdate, onProjectDelete
}: Props) {
    const me = useMe();
    const setProjects = useSetProjects();
    const translate = useTranslate();
    const all = translate('all');
    
    const projects = useMemo(() => me.projects
        .filter(p => renderCards || !languageFilter || (languageFilter === all || p.language === languageFilter))
        .filter(p => renderCards || !projectFilter || (projectFilter === all || p.projectType === projectFilter))
        .filter(p => renderCards || p.display)
        .reverse(), 
    [languageFilter, projectFilter, me, me.projects])

    useEffectOnce(() => { if (!me.projects.length) setProjects(); })

    return (
        <div className='project-container' data-render-cards={renderCards}>
            {(projects.length && projects.map(p => 
                !renderCards ? 
                    <ProjectComponent project={p} key={`${p.name}_${p._id}`} /> :
                    <ProjectCard project={p} key={`${p.name}_${p._id}`} 
                        onUpdate={onProjectUpdate} onDelete={onProjectDelete}
                    />
                )) || <h1>{translate('noProjects')}</h1>
            }
        </div>
    )
}
