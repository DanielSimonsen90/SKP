import { ChangeEvent, useEffect, useRef, useState } from "react";
import { BaseProps, Button, UseStateSetState } from "danholibraryrjs";
import { Project } from "danhosaurportfolio-models";

import { useTranslate } from "providers/LanguageProvider";
import { useModal } from "providers/ModalProvider";

import LoadData from "components/shared/LoadData";
import { ImageContainer } from "components/shared/container/SpecificContainer";

import ProjectImageModal from "./ProjectImageModal";

export const ImageSrcPrefix = 'data:image/png;base64,';

type Props = BaseProps<HTMLImageElement> & {
    project: Project,
    modalable?: boolean,
    changable?: boolean,

    onSrcChange?: (value: string) => void
}
type ProjectImageChangeableProps = {
    setSrc: UseStateSetState<string>,
    prefixSrc(value: string): string
}

function ProjectImageChangeable({ setSrc, prefixSrc }: ProjectImageChangeableProps) {
    const [image, setImage] = useState<string | ArrayBuffer>("");
    const [loading, setLoading] = useState(false);
    const [file, setFile] = useState<File>(null);

    useEffect(() => { if (image) setSrc(prefixSrc(image.toString())); }, [image]);
    useEffect(() => { setLoading(file !== null && file !== undefined); }, [file]);

    const inputRef = useRef<HTMLInputElement>();
    const onChange = (e: ChangeEvent<HTMLInputElement>) => {
        e.stopPropagation();
        setFile(e.target.files[0]);
    };
    const loadData = () => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = () => {
            if (reader.readyState === 2) {
                setImage(reader.result);
                setLoading(false);
                resolve(reader.result);
            }
        }
        reader.readAsDataURL(file);
    });

    if (loading) return (
        <LoadData loadData={loadData} />
    )

    return (<>
        <input ref={inputRef} style={{ display: 'none' }} type="file" id="project-image-change" onChange={onChange} />
        <Button importance="secondary" onClick={e => {
            e.stopPropagation();
            inputRef.current.click();
        }}>Upload Project Image</Button>
    </>)
}

export default function ProjectImage({ project, onSrcChange, changable = false, modalable = true, className, ...props }: Props) {
    const translate = useTranslate();
    const prefixSrc = (value: string) => {
        const strVal = value && typeof value !== 'string' ? (value as any as Buffer).toString("base64") : value;
        return strVal && !strVal.includes(ImageSrcPrefix) ? `${ImageSrcPrefix}${value}` : value
    };
    const [src, setSrc] = useState(prefixSrc(project?.image || ""));
    const [setModalVisibility] = useModal(<ProjectImageModal project={project} />);

    useEffect(() => { onSrcChange?.(src); }, [src]);

    if (!src || src === prefixSrc('[object Object]')) 
        return (<>
            <p className="project-image">{translate('noImage')}</p>
            {changable && <ProjectImageChangeable  setSrc={setSrc} prefixSrc={prefixSrc} />}
        </>)

    return (
        <>
            <ImageContainer>
                <img className={`project-image${className ? ` ${className}` : ''}`} 
                    src={src} {...props} data-clickable={modalable}
                    alt="Project preview" tabIndex={modalable ? 0 : -1}
                    onClick={() => modalable && setModalVisibility('show')}
                    onKeyDown={e => (e.key === 'Enter' || e.key === 'NumpadEnter') && modalable && setModalVisibility('show')}
                />
            </ImageContainer>
            {changable && <ProjectImageChangeable  setSrc={setSrc} prefixSrc={prefixSrc} />}
        </>
    )
}