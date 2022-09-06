import { useMemo, useState } from 'react'
import { Project, IProject, ProgrammingLanguage } from 'danhosaurportfolio-models';
import { Button, Component, CRUD, useEnterEsc, useStateUpdate } from 'danholibraryrjs';
import { BetterOmit, TransformType } from 'danholibraryjs';

import { useUpsertProject, api, useSetProjects } from 'providers/MeProvider';
import { ModalProps } from 'providers/ModalProvider';

import InfoContainer from 'components/shared/container/InfoContainer';
import { ButtonContainer } from 'components/shared/container/SpecificContainer';

import useProjectInformation from './useProjectInformation';
import useProjectOptional from './useProjectOptional';

import { ModalTitles } from '..';
import './ProjectModal.scss';

export type ConstructableProps = BetterOmit<Project & IProject<ProgrammingLanguage>, '_id' | 'toString'>;
export type UseProjectModifyReturn<P> = [component: Component, didChange: boolean, props: P]
export type ProjectModalProps = ModalProps & {
    project: Project | undefined,
    title: ModalTitles
}
export type ProjectModalHookProps = BetterOmit<ProjectModalProps, 'close'>

export default function ProjectModal({ title, project, close }: ProjectModalProps) {
    useEnterEsc({ onEnter: () => propsChanged && onConstruct(), onEsc: close })

    const [ProjectInformation, infoChanged, projectInfoProps] = useProjectInformation({ project, title: 'Project Information' })
    const [ProjectOptional, optionalChanged, projectOptionalProps] = useProjectOptional({ project, title: 'Optional' });
    const projectProps = useMemo(() => {
        const { createdAt, description, display, language, name, projectType } = projectInfoProps;
        const { collab, image, spareTime, link } = projectOptionalProps;

        const shell = new Project(name, { 
            display, createdAt, language, projectType,
            description, link, spareTime,
            collab, image
        });

        // console.log(shell);

        return Object.assign({}, project, shell) as Project
    }, [projectInfoProps, projectOptionalProps]);
    const propsChanged = useStateUpdate(false, {
        before: () => Object.keysOf(projectProps).some(prop => {
            if (!project) return true;


            const projectExists = project !== null || project !== undefined;
            const propsUnequal = projectProps[prop] !== project[prop];
            const propIsObj = typeof project[prop] === 'object';
            const propObjKeysUnequal = () => {
                try {
                    Object.keysOf(project[prop]).some(key => {
                        if (key === 'hasLink') return false;

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
                    console.error(err, {
                        project: project[prop],
                        value: projectProps[prop],
                        prop
                    })   
                    return false;
                }
            }

            const value = projectExists && propsUnequal && (propIsObj ? propObjKeysUnequal() : true);
            /*console.log({ 
                data: {
                    project: project[prop], shell: projectProps[prop]
                },
                booleans: {
                    projectExists, propsUnequal, propIsObj
                },
                value
            })*/

            if (value) {
                // console.log('Changed properties', {
                //     booleans: {
                //         projectExists, propsUnequal, propIsObj, 
                //         propObjKeysUnequal: propObjKeysUnequal()
                //     },
                //     project: project[prop],
                //     value: projectProps[prop]
                // });
                return true;
            }
            return false;
        }),
        //TODO: Remove when library is updated
        after: () => {}
    }, 
        [infoChanged, optionalChanged]
    );
    const upsertProject = useUpsertProject();

    const onConstruct = () => {
        // console.log(projectProps);
        upsertProject(projectProps).then(close)
    };

    if (title === 'delete' && project) return <DeleteModal title={title} project={project} close={close} />

    return (
        <form action={title === 'create' ? 'post' : title === 'update' ? 'put' : title} onSubmit={e => {
            e.preventDefault();
            e.stopPropagation();
            onConstruct();
        }}>
            <InfoContainer title={`${title} Project`}>
                {ProjectInformation}
                {ProjectOptional}
                <ButtonContainer>
                    <Button importance='primary' type="submit" disabled={!propsChanged} crud={title as CRUD}>{title.toPascalCase()}</Button>
                    <Button importance='secondary' crud='delete' iconName='times' onClick={e => {
                        e.preventDefault();
                        close();
                    }}>Close</Button>
                </ButtonContainer>
            </InfoContainer>
        </form>
    )
}

function DeleteModal({ title, project, close }: TransformType<ProjectModalProps, Project | undefined, Project>) {
    const setProjects = useSetProjects();
    const loadingModal = <h1>Deleting project...</h1>;
    const deletedModal = <h1>{project.name} was deleted from the database.</h1>
    const [content, setContent] = useState(<>
        <h1>Are you sure you want to delete <u>{project.name}</u>?</h1>
        <ButtonContainer>
            <Button crud="delete" importance='primary' onClick={() => onChoice('yes')}>Delete</Button>
            <Button iconName='times' crud="delete" importance="secondary" onClick={() => onChoice('no')}>Cancel</Button>
        </ButtonContainer> 
    </>)

    const onChoice = async (value: string) => {
        if (value !== 'yes') return close();

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