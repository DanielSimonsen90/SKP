import { BaseProps } from "danholibraryrjs";
import { Project } from "danhosaurportfolio-models";
import { useTranslate } from "providers/LanguageProvider";
import { useModal } from "providers/ModalProvider";
import ProjectImageModal from "./ProjectImageModal";

type Props = BaseProps<HTMLImageElement> & {
    project: Project,
    allowClick?: boolean
}

export default function ProjectImage({ project, allowClick = true, className, ...props }: Props) {
    const translate = useTranslate();
    const modal = useModal(<ProjectImageModal project={project} />);
    
    let source = project.image;
    if (project.image === undefined || project.image.toString() === '[object Object]') return <p className="project-image">{translate('noImage')}</p>;
    if (project.image.toString() === '[object Object]') console.log('[object Object]:', project.image);
    
    const src = `data:image/png;base64,${source}`

    return <img className={`project-image${className ? ` ${className}` : ''}`} 
        src={src} {...props} data-clickable={allowClick}
        alt="Project preview failed to load..."
        onClick={e => { 
            // e.stopPropagation();
            if (allowClick) modal('show');
         }} 
    />
}