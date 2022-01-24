import { BaseProps } from "danholibraryrjs";
import { Project } from "danhosaurportfolio-models";
import { useTranslate } from "providers/LanguageProvider";
import LinkItem from '../../../shared/navigation/LinkItem';

type Props = Omit<BaseProps<HTMLLIElement>, 'onClick'> & {
    project: Project
}

export default function ProjectLink({ project, className, ...props }: Props) {
    const translate = useTranslate();
    const seeMyProject = (() => {
        const [start, end] = translate('seeMyProject').split('$projectName');
        return <>{start}<b>{project.name}</b>{end}</>
    })();

    if (!project.link || project.link === 'No link') return null;
    return ( 
        <LinkItem link={project.link} className={`project-link${className ? ` ${className}` : ''}`}
            children={seeMyProject}
            newPage={true} {...props}
        />
    )   
}