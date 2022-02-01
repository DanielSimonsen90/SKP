import { useEffect, useMemo, useState } from 'react'
import { useEnterEsc, useRedirect, useStateOnUpdate } from 'danholibraryrjs';
import { Project, IProject, ProgrammingLanguage, API } from 'danhosaurportfolio-models'
import { useUpsertProject, api } from 'providers/MeProvider';
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
    const redirect = useRedirect();
    useEnterEsc({ onEnter: () => onConstruct(), onEsc: close })

    const [ProjectInformation, infoChanged, projectInfoProps] = useProjectInformation({ project, title: 'Project Information' })
    const [ProjectOptional, optionalChanged, projectOptionalProps] = useProjectOptional({ project, title: 'Optional' });
    const projectProps = useMemo(() => 
        Object.assign({}, project, projectInfoProps, projectOptionalProps) as Project, 
    [projectInfoProps, ProjectOptional]);
    const propsChanged = useStateOnUpdate(false, 
        () => Object.keys(projectProps).some(prop => {
            if (!project) return true;

            // console.log({
            //     project, projectProps
            // });

            const projectExists = project !== null || project !== undefined;
            const propsUnequal = projectProps[prop] !== project[prop];
            const propIsObj = typeof project[prop] === 'object';
            const propObjKeysUnequal = () => {
                try {
                    Object.keys(project[prop]).some(key => {
                        try {
                            return project[prop][key] !== projectProps[prop][key]
                        } catch (err) {
                            console.error(err, {
                                project: project[prop],
                                value: projectProps[prop],
                                key
                            });
                            return false;
                        }
                    })
                } catch (err) {
                    // console.error(err, {
                    //     project: project[prop],
                    //     value: projectProps[prop],
                    //     prop
                    // })   
                    return false;
                }
            }

            const value = projectExists && propsUnequal && (propIsObj ? propObjKeysUnequal() : true);
            if (value) {
                console.log('Changed properties', {
                    booleans: {
                        projectExists, propsUnequal, propIsObj, 
                        propObjKeysUnequal: propObjKeysUnequal()
                    },
                    project: project[prop],
                    value: projectProps[prop]
                });
                return true;
            }
            return false;
        }), 
        [infoChanged, optionalChanged]
    );
    const upsertProject = useUpsertProject();

    const onConstruct = () => upsertProject(projectProps).then(close);

    if (title === 'delete') return <DeleteModal title={title} project={project} close={close} />

    const crudProp = { 'data-crud-type': title };
    
    return (
        <InfoContainer title={`${title} Project`} onKeyPress={e => console.log(e)}>
            {ProjectInformation}
            {ProjectOptional}
            <ButtonContainer>
                <button className='primary' onClick={onConstruct} disabled={!propsChanged} {...crudProp}>{title.toPascalCase()}</button>
                <button className='secondary' onClick={close} data-crud-type='delete' >Close</button>
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
            <button className="secondary" onClick={() => onChoice('no')}>Cancel</button>
            <button className="primary" onClick={() => onChoice('yes')} data-crud-type="delete">Delete</button>
        </ButtonContainer> 
    </>);
    const loadingModal = <h1>Deleing project...</h1>;
    const deletedModal = <h1>{project.name} was deleted from the database.</h1>

    const [content, setContent] = useState(defaultModal)

    const onChoice = async (value: string) => {
        if (value !== 'yes') close();

        setContent(loadingModal);
        await api.delete('projects', project);
        setContent(deletedModal);
        setTimeout(close, 3000);
    }

    return (
        <InfoContainer title={title} onKeyPress={e => console.log(e.key)}>
            {content}
        </InfoContainer>
    )
}