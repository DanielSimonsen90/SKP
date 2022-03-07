import { BaseProps } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';

import Bookmark from 'components/sites/Projects/Bookmark';
import ProjectLanguage from '../../ProjectLanguage';
import { useLanguageColor } from '../../hooks/useLanguageColor';

import './ProjectCardHead.scss';

type Props = BaseProps & {
    project: Project,
    allowCrud: boolean
}

export default function ProjectCardHead({ allowCrud, project }: Props) {
    const { 
        _id, name, language, projectType,
        createdAt, display, spareTime 
    } = project;
    const languageColor = useLanguageColor(language, 'mix');

    if (_id === undefined || _id === null) console.error('Project has no id', project);

    return (
        <header className='project-card-head'>
            <h1 className="project-card-head-title" title={name} style={{ color: languageColor }}>{name}</h1>
            {allowCrud && (<>
                <span className="project-card-head-id">{_id}</span>
                <label className="project-card-head-display" >
                    {display ? 'Shown' : 'Hidden'}
                    <input type="checkbox" 
                        name="display" id="display"
                        disabled={true} checked={display} 
                    />
                </label>    
            </>)}
            {!allowCrud && <Bookmark className='project-card-bookmark' project={project} />}
            <h3 className="project-card-head-info">
                <time dateTime={createdAt.toStringReverse()}>{createdAt.toString()}</time>
                <ProjectLanguage language={language} />
                <p title={projectType}>{projectType}</p>
            </h3>
            <label className="project-card-head-spare-time">
                SpareTime
                <input type="checkbox" 
                    name="spare-time" id="spare-time" 
                    disabled={true} checked={spareTime}    
                />
            </label>
        </header>
    );
}