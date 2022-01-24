import { useEffect, useState } from 'react';
import { Project } from 'danhosaurportfolio-models';
import { useModal } from 'providers/ModalProvider';
import ProjectModal from './ProjectModal';
import ProjectContainer from '../../Projects/ProjectContainer';
import './ProjectManagement.scss';

export type ModalTitles = 'create' | 'update' | 'delete' | string;

export default function ProjectManagement() {
    const [project, setProject] = useState<Project>(null);
    const [modalTitle, setModalTitle] = useState<ModalTitles>("create");
    const [showModal, setShowModal] = useState(false);
    const modal = useModal(<ProjectModal title={modalTitle} project={project} close={() => setShowModal(false)} />)
    const openModal = (title: ModalTitles, project?: Project) => {
        setProject(project);
        setModalTitle(title);
        setShowModal(true);
    }

    useEffect(() => {
        modal(showModal ? 'show' : 'hide');
    }, [showModal])

    return (
        <div id='project-management'>
            <button onClick={() => openModal('create')}>Create Project</button>
            <ProjectContainer renderCards={true} 
                onProjectUpdate={p => openModal('update', p)}
                onProjectDelete={p => openModal('delete', p)}
            />
        </div>
    )
}
