import { ImageContainer } from 'components/shared/container/SpecificContainer';
import { BaseProps } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import ProjectImage from '../ProjectImage';
import './ProjectImageModal.scss';

type Props = BaseProps & {
    project: Project,
    src?: string
}

export default function ProjectImageModal({ project, src }: Props) {
    return (
        <div className='project-image-modal'>
            <h1>{project.name}</h1>
            <ImageContainer>
                <ProjectImage project={project} src={src} modalable={false} />
            </ImageContainer>
        </div>
    );
}