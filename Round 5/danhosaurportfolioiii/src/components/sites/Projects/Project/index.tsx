import { useMemo } from 'react';
import { Admin, Project } from 'danhosaurportfolio-models';
import { useMediaQuery, useSessionStorage } from 'danholibraryrjs';

import { useLanguage, useTranslate } from 'providers/LanguageProvider';
import LinkItem from 'components/shared/navigation/LinkItem';

import Bookmark from '../Bookmark';

import ProjectImage from './ProjectImage';
import ProjectLink from './ProjectLink';
import ProjectLanguage from './ProjectLanguage';
import { useLanguageColor } from './hooks/useLanguageColor';
import useContextMenu from './hooks/useContextMenu';
import './Project.scss';
import { useFindAdmin } from 'providers/AdminProvider';
import ProjectModal from 'components/sites/Admin/ProjectManagement/ProjectModal';

type Props = {
    project: Project
}

export default function ProjectComponent({ project }: Props) {
    const [language] = useLanguage();
    const translate = useTranslate();
    const isMicro = useMediaQuery("400");
    const [admin] = useSessionStorage<'admin', Admin>('admin', null);
    const findAdmin = useFindAdmin();
    const isAdmin = useMemo(() => admin?.username && findAdmin(admin.username) != null, [admin]);

    const seeMyProject = useMemo(() => {
        const [start, end] = translate('seeMyProject').split('$projectName');
        return <>{start}<b>{project.name}</b>{end}</>
    }, [project, language]);
    const languageColor = useLanguageColor(project.language, 'mix');
    useContextMenu(`[data-project-id="${project._id}"]`, ({ visible, toggle }) => (
        <ProjectModal close={() => visible && toggle('hide')} project={project} title='update' />
    ), [isAdmin]);

    function handleSentenceMapping(sentence: string, key: number) {
        if (!sentence) return <br key={`${project.name}-${key}`}/>;
        else if (sentence.startsWith('http')) return (
            <LinkItem link={sentence} key={`${project.name}-${key}`}
                newPage={true} children={seeMyProject}
            />
        )
        else return <p key={`${project.name}-${key}`}>{sentence}</p>
    }

    return (
        <article className='project container-flex container' id={project.name.replaceAll(' ', '%20').replaceAll('.', '')} {...{ 'data-project-id': project._id }}>
            <header>
                <h1>
                    <span style={{ color: languageColor, borderColor: languageColor }}>{project.name}</span>
                    <Bookmark project={project} />
                </h1>
                <h2> 
                    <time dateTime={project.createdAt.toStringReverse()}>{project.createdAt.toString()}</time>
                    {!isMicro && <span> • </span>}
                    <ProjectLanguage language={project.language} />
                    {!isMicro && <span> • </span>}
                    <span>{project.projectType.toString()}</span>
                </h2>
            </header>
            <section className="project-info" style={{ borderColor: languageColor }}>
                <div className="project-description">
                    {project.description[language].map(handleSentenceMapping)}
                </div>
                <ProjectLink project={project} style={{ borderColor: languageColor }} />
                <ProjectImage project={project} />
            </section>
        </article>
    )
}
