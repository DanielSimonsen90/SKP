import { BaseProps } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import ProjectImage from '../ProjectImage';
import './ProjectImageModal.scss';

type Props = BaseProps & {
    project: Project
}

export default function ProjectImageModal({ project }: Props) {
    return (
        <div className='project-image-modal'>
            <h1>{project.name}</h1>
            <div className="image-container">
                <ProjectImage project={project} modalable={false} />
            </div>
        </div>
    );
}