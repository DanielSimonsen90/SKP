import { useMemo, useState } from 'react'
import { useEnterEsc, useRedirect, useStateOnUpdate } from 'danholibraryrjs';
import { Project, IProject, ProgrammingLanguage } from 'danhosaurportfolio-models'
import { useUpsertProject, api, github, useSetProjects } from 'providers/MeProvider';
import { ModalProps } from 'providers/ModalProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import { ButtonContainer } from 'components/shared/container/SpecificContainer';
import useProjectInformation from './useProjectInformation';
import useProjectOptional from './useProjectOptional';
import { ModalTitles } from '..';
import './ProjectModal.scss';

export type Omid<T, Keys extends keyof T> = Omit<T, Keys>;
export type ConstructableProps = Omid<Project & IProject<ProgrammingLanguage>, 
    '_id' | 'toString' | 'link' | 'githubUsername'
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
    const projectProps = useMemo(() => {
        const { createdAt, description, display, language, name, projectType } = projectInfoProps;
        const { collab, image, spareTime, baseLink, hasLink } = projectOptionalProps;

        const shell = new Project(name, { 
            display, createdAt, language, projectType,
            description, hasLink, baseLink, spareTime,
            collab, image, githubUsername: github
        });

        return Object.assign({}, project, shell) as Project
    }, [projectInfoProps, ProjectOptional]);
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

    const onConstruct = () => {
        console.log(projectProps);
        upsertProject(projectProps).then(close)
    };

    if (title === 'delete') return <DeleteModal title={title} project={project} close={close} />

    const crudProp = { 'data-crud-type': title };
    
    return (
        <form action="post" onSubmit={e => {
            e.preventDefault();
            onConstruct();
        }}>
            <InfoContainer title={`${title} Project`}>
                {ProjectInformation}
                {ProjectOptional}
                <ButtonContainer>
                    <button className='primary' type='submit' disabled={!propsChanged} {...crudProp}>{title.toPascalCase()}</button>
                    <button className='secondary' onClick={close} data-crud-type='delete'>Close</button>
                </ButtonContainer>
            </InfoContainer>
        </form>
    )
}

function DeleteModal({ title, project, close }: ProjectModalProps) {
    const setProjects = useSetProjects();

    const defaultModal = (<>
        <h1>
            Are you sure you want to delete 
            <u>{project.name}</u>
            ?
        </h1>
        <ButtonContainer>
            <button className="primary" onClick={() => onChoice('yes')} data-crud-type="delete">Delete</button>
            <button className="secondary" onClick={() => onChoice('no')}>Cancel</button>
        </ButtonContainer> 
    </>);
    const loadingModal = <h1>Deleing project...</h1>;
    const deletedModal = <h1>{project.name} was deleted from the database.</h1>

    const [content, setContent] = useState(defaultModal)

    const onChoice = async (value: string) => {
        if (value !== 'yes') close();

        setContent(loadingModal);
        await api.delete('projects', project, console.error);
        setContent(deletedModal);
        setProjects(true);
        setTimeout(close, 1000);
    }

    return (
        <InfoContainer title={title}>
            {content}
        </InfoContainer>
    )
}