import { useMemo, useState } from 'react'
import { useStateOnUpdate } from 'danholibraryrjs';
import { Project, IProject, ProgrammingLanguage } from 'danhosaurportfolio-models'
import { api, useUpsertProject } from 'providers/MeProvider';
import { ModalProps } from 'providers/ModalProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import { ButtonContainer } from 'components/shared/container/SpecificContainer';
import useProjectInformation from './useProjectInformation';
import useProjectOptional from './useProjectOptional';
import { ModalTitles } from '..';
import './ProjectModal.scss';

export type Omid<T, Keys extends keyof T> = Omit<T, Keys>;
export type ConstructableProps = Omid<Project & IProject<ProgrammingLanguage>, 
    '_id' | 'toString' | 'link'
>
export type UseProjectModifyReturn<P> = [component: JSX.Element, didChange: boolean, props: P]
export type ProjectModalProps = ModalProps & {
    project: Project | null,
    title: ModalTitles
}
export type ProjectModalHookProps = Omit<ProjectModalProps, 'close'>

export default function ProjectModal({ title, project, close }: ProjectModalProps) {
    // console.log(project);

    const [ProjectInformation, infoChanged, projectInfoProps] = useProjectInformation({ project, title: 'Project Information' })
    const [ProjectOptional, optionalChanged, projectOptionalProps] = useProjectOptional({ project, title: 'Optional' });
    const projectProps = useMemo(() => 
        Object.assign({}, project, projectInfoProps, projectOptionalProps) as Project, 
    [projectInfoProps, ProjectOptional]);
    const propsChanged = useStateOnUpdate(false, 
        () => Object.keys(projectProps).some(key => project && projectProps[key] !== project[key]), 
        [infoChanged, optionalChanged]
    );
    const upsertProject = useUpsertProject();

    const onConstruct = () => upsertProject(projectProps);

    if (title === 'delete') return <DeleteModal title={title} project={project} close={close} />

    const crudProp = { 'data-crud-type': title };
    
    return (
        <InfoContainer title={`${title} Project`}>
            {ProjectInformation}
            {ProjectOptional}
            <ButtonContainer>
                <button onClick={onConstruct} disabled={!propsChanged}
                    {...crudProp}
                >{title.toPascalCase()}</button>
                <button onClick={close}>Close</button>
            </ButtonContainer>
        </InfoContainer>
    )
}

function DeleteModal({ title, project, close }: ProjectModalProps) {
    const defaultModal = (<>
        <h1>
            Are you sure you want to delete 
            <u>{project.name}</u>
            ?
        </h1>
        <ButtonContainer>
            <button onClick={() => onChoice('no')}>Cancel</button>
            <button onClick={() => onChoice('yes')} data-crud-type="delete">Delete</button>
        </ButtonContainer> 
    </>);
    const loadingModal = <h1>Deleing project...</h1>;
    const deletedModal = <h1>{project.name} was deleted form the database.</h1>

    const [content, setContent] = useState(defaultModal)

    const onChoice = async (value: string) => {
        if (value !== 'yes') close();

        setContent(loadingModal);
        await api.delete('projects', project);
        setContent(deletedModal);
        setTimeout(close, 3000);
    }

    return (
        <InfoContainer title={title}>
            {content}
        </InfoContainer>
    )
}