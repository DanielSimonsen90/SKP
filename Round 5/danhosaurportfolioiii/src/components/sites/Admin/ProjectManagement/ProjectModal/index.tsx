import { useMemo, useState } from 'react'
import { Project, IProject, ProgrammingLanguage } from 'danhosaurportfolio-models';
import { Button, CRUD, useEnterEsc, useStateOnUpdate } from 'danholibraryrjs';
import { BetterOmit } from 'danholibraryjs';

import { useUpsertProject, api, github, useSetProjects } from 'providers/MeProvider';
import { ModalProps } from 'providers/ModalProvider';

import InfoContainer from 'components/shared/container/InfoContainer';
import { ButtonContainer } from 'components/shared/container/SpecificContainer';

import useProjectInformation from './useProjectInformation';
import useProjectOptional from './useProjectOptional';

import { ModalTitles } from '..';
import './ProjectModal.scss';

export type ConstructableProps = BetterOmit<Project & IProject<ProgrammingLanguage>, 
    '_id' | 'toString' | 'link' | 'githubUsername'
>
export type UseProjectModifyReturn<P> = [component: JSX.Element, didChange: boolean, props: P]
export type ProjectModalProps = ModalProps & {
    project: Project | null,
    title: ModalTitles
}
export type ProjectModalHookProps = BetterOmit<ProjectModalProps, 'close'>

export default function ProjectModal({ title, project, close }: ProjectModalProps) {
    useEnterEsc({ onEnter: () => propsChanged && onConstruct(), onEsc: close })

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

    return (
        <form action="post" onSubmit={e => {
            e.preventDefault();
            onConstruct();
        }}>
            <InfoContainer title={`${title} Project`}>
                {ProjectInformation}
                {ProjectOptional}
                <ButtonContainer>
                    <Button importance='primary' type="submit" disabled={!propsChanged} crud={title as CRUD}>{title.toPascalCase()}</Button>
                    <Button importance='secondary' onClick={close} crud='delete'>Close</Button>
                </ButtonContainer>
            </InfoContainer>
        </form>
    )
}

function DeleteModal({ title, project, close }: ProjectModalProps) {
    const setProjects = useSetProjects();

    const defaultModal = (<>
        <h1>Are you sure you want to delete <u>{project.name}</u>?</h1>
        <ButtonContainer>
            <Button crud="delete" importance='primary' onClick={() => onChoice('yes')}>Delete</Button>
            <Button crud="delete" importance="secondary" onClick={() => onChoice('no')} hideIcon>Cancel</Button>
        </ButtonContainer> 
    </>);
    const loadingModal = <h1>Deleting project...</h1>;
    const deletedModal = <h1>{project.name} was deleted from the database.</h1>

    const [content, setContent] = useState(defaultModal)

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