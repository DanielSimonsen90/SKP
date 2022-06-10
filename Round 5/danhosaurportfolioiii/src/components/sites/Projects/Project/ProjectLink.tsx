import { BaseProps, classNames } from "danholibraryrjs";
import { Project } from "danhosaurportfolio-models";
import { useTranslate } from "providers/LanguageProvider";
import LinkItem, { LinkItemProps } from '../../../shared/navigation/LinkItem';

type Props = Omit<LinkItemProps, 'onClick'> & {
    project: Project
}

export default function ProjectLink({ project, className, ...props }: Props) {
    const translate = useTranslate();
    const seeMyProject = (() => {
        const [start, end] = translate('seeMyProject').split('$projectName');
        return <>{start}<b>{project.name}</b>{end}</>
    })();

    if (!project.link || project.link === 'No link') {        
        return null
    };
    return ( 
        <LinkItem className={classNames('project-link', className)} 
            listElement={false} link={project.link} 
            children={seeMyProject} newPage {...props}
        />
    )   
}