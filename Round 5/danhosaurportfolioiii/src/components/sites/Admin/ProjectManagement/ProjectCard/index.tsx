import { BaseProps, Container } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import { useLanguage } from 'providers/LanguageProvider';
import ProjectImage from '../../../Projects/Project/ProjectImage';
import ProjectCardHead from './ProjectCardHead';
import './ProjectCard.scss';
import { ButtonContainer, ImageContainer } from 'components/shared/container/SpecificContainer';

type Props = BaseProps & {
  project: Project,
  onUpdate: (project: Project) => void,
  onDelete: (project: Project) => void
}

export default function ProjectCard({ project, onUpdate, onDelete }: Props) {
  const [language] = useLanguage();

  return (
    <Container className='project-card' id={project.name.replaceAll(' ', '%20')}>
      <ProjectCardHead project={project} />
      <textarea className='project-card-mid-top' 
        readOnly
        value={project.description[language]} 
      />
      <ImageContainer className='project-card-mid-bottom'>
        <ProjectImage project={project} modalable={true} />
      </ImageContainer>
      <ButtonContainer className='project-card-bottom'>
        <button data-crud-type="update" className='primary' onClick={() => onUpdate(project)}>Update</button>
        <button data-crud-type="delete" className='secondary' onClick={() => onDelete(project)}>Delete</button>
      </ButtonContainer>
    </Container>
  );
}