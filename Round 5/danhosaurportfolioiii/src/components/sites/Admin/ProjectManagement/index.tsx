import { Project } from 'danhosaurportfolio-models';
import { useModal } from 'providers/ModalProvider';
import ProjectModal from './ProjectModal';
import ProjectContainer from '../../Projects/ProjectContainer';
import './ProjectManagement.scss';
import { useMe } from 'providers/MeProvider';

export type ModalTitles = 'create' | 'update' | 'delete' | string;

export default function ProjectManagement() {
    const projects = useMe().projects;
    const modalClose = () => setModalVisible('hide');
    const defaultModal = <ProjectModal title="create" project={null} close={modalClose} />;
    const [visible, setModalVisible] = useModal(defaultModal)
    const openModal = (title: ModalTitles, project?: Project) => {
        setModalVisible('show', <ProjectModal project={project} title={title} close={modalClose} />)
    }

    return (
        <div id='project-management'>
            {projects.length && (
                <button onClick={() => openModal('create')} data-crud-type="create">Create Project</button>
            )}
            <ProjectContainer renderCards={true} 
                onProjectUpdate={p => openModal('update', p)}
                onProjectDelete={p => openModal('delete', p)}
            />
        </div>
    )
}
