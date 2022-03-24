import { BaseProps, Button, Container } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';

import { ButtonContainer, ImageContainer } from 'components/shared/container/SpecificContainer';
import { useLanguage } from 'providers/LanguageProvider';

import { useLanguageColor } from '../hooks/useLanguageColor';

import ProjectImage from '../ProjectImage';
import ProjectCardHead from './ProjectCardHead';
import './ProjectCard.scss';

type Props = BaseProps & {
  project: Project,
  allowCrud: boolean,
  onUpdate: (project: Project) => void,
  onDelete: (project: Project) => void
}

export default function ProjectCard({ allowCrud, project, onUpdate, onDelete }: Props) {
  const [language] = useLanguage();
  const languageColor = useLanguageColor(project.language, "opacity");

  return (
    <Container className='project-card' id={project.name.replaceAll(' ', '%20')} style={{
      boxShadow: `0px 5px 5px ${languageColor}`,
      border: `1px solid ${languageColor}`
    }}>
      <ProjectCardHead project={project} allowCrud={allowCrud} />
      <textarea className='project-card-mid-top' 
        readOnly
        value={project.description[language]} 
      />
      <ImageContainer className='project-card-mid-bottom'>
        <ProjectImage project={project} modalable={true} />
      </ImageContainer>
      {allowCrud && (
        <ButtonContainer className='project-card-bottom'>
          <Button crud='update' importance='primary' onClick={() => onUpdate(project)}>Update</Button>
          <Button crud='delete' importance='secondary' onClick={() => onDelete(project)}>Delete</Button>
        </ButtonContainer>
      )}
    </Container>
  );
}