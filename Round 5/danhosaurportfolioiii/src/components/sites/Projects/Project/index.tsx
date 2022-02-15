import { Container } from 'danholibraryrjs'
import { Project } from 'danhosaurportfolio-models'
import { useModal } from 'providers/ModalProvider'
import { useLanguage, useTranslate } from 'providers/LanguageProvider'
import LinkItem from 'components/shared/navigation/LinkItem'
import ProjectImage from './ProjectImage'
import Bookmark from '../Bookmark'
import './Project.scss'
import ProjectLink from './ProjectLink'
import ProjectImageModal from './ProjectImageModal'
import ProjectLanguage from './ProjectLanguage'

type Props = {
    project: Project
}

export default function ProjectComponent({ project }: Props) {
    const [language] = useLanguage();
    const translate = useTranslate();
    const seeMyProject = (() => {
        const [start, end] = translate('seeMyProject').split('$projectName');
        return <>{start}<b>{project.name}</b>{end}</>
    })();

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
        <article className='project container-flex container' id={project.name.replaceAll(' ', '%20')}>
            <header>
                <h1>{project.name}</h1>
                <h2>
                    <span>{project.createdAt.toString()}</span>
                    <span> • </span>
                    <ProjectLanguage language={project.language} />
                    <span> • </span>
                    <span>{project.projectType.toString()}</span>
                </h2>
                <Bookmark project={project} />
            </header>
            <section className="project-info">
                <div className="project-description">
                    {project.description[language].map(handleSentenceMapping)}
                </div>
                <ProjectLink project={project} />
                <ProjectImage project={project} />
            </section>
        </article>
    )
}
