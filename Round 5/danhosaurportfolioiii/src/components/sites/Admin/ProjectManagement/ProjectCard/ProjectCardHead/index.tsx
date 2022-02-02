import { BaseProps } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import './ProjectCardHead.scss';

type Props = BaseProps & {
    project: Project
}

export default function ProjectCardHead({ 
    project: { 
        _id, name, language, projectType,
        createdAt, display, spareTime 
    } 
}: Props) {
    return (
        <div className='project-card-head'>
            <p className="project-card-head-id">{_id}</p>
            <h1 className="project-card-head-title" title={name}>{name}</h1>
            <label>
                {display ? 'Shown' : 'Hidden'}
                <input type="checkbox" 
                    className="project-card-head-display" name="display" id="display"
                    disabled={true} checked={display} 
                />
            </label>
            <h3 className="project-card-head-info">
                <p>{language}</p>
                <p>{projectType}</p>
                <p>{createdAt.toString()}</p>
            </h3>
            <label>
                SpareTime
                <input type="checkbox" 
                    className="project-card-head-spare-time" name="spare-time" id="spare-time" 
                    disabled={true} checked={spareTime}    
                />
            </label>
        </div>
    );
}