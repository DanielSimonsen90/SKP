import { BaseProps } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import './ProjectCardHead.scss';

type Props = BaseProps & {
    project: Project
}

export default function ProjectCardHead({ project }: Props) {
    const { 
        _id, name, language, projectType,
        createdAt, display, spareTime 
    } = project;

    if (_id === undefined || _id === null) console.error('Project has no id', project) 

    return (
        <header className='project-card-head'>
            <h1 className="project-card-head-title" title={name}>{name}</h1>
            <span className="project-card-head-id">{_id}</span>
            <label className="project-card-head-display" >
                {display ? 'Shown' : 'Hidden'}
                <input type="checkbox" 
                    name="display" id="display"
                    disabled={true} checked={display} 
                />
            </label>
            <h3 className="project-card-head-info">
                <p>{language}</p>
                <p>{projectType}</p>
                <p>{createdAt.toString()}</p>
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