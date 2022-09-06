import { Project } from 'danhosaurportfolio-models';
import { Button } from 'danholibraryrjs';

import { useModal } from 'providers/ModalProvider';
import { useMe } from 'providers/MeProvider';

import { ButtonContainer } from 'components/shared/container/SpecificContainer';

import ProjectContainer from '../../Projects/ProjectContainer';
import ProjectModal from './ProjectModal';
import ResetSessionButton from './ResetSessionButton';
import './ProjectManagement.scss';

export type ModalTitles = 'create' | 'update' | 'delete' | string;

export default function ProjectManagement() {
    const { projects } = useMe();
    const close = () => toggleModal('hide');
    const [toggleModal] = useModal(<ProjectModal title="create" project={undefined} close={close} />)
    const openModal = (title: ModalTitles, project?: Project) => {
        toggleModal('show', <ProjectModal project={project} title={title} close={close} />)
    }

    return (
        <div id='project-management'>
            {projects.length > 0 && (
                <ButtonContainer>
                    <Button importance='tertiary' crud='create' onClick={() => openModal('create')}>Create Project</Button>
                    <ResetSessionButton />
                </ButtonContainer>
            )}
            <ProjectContainer renderCards allowCrud
                onProjectUpdate={p => openModal('update', p)}
                onProjectDelete={p => openModal('delete', p)}
            />
        </div>
    )
}
