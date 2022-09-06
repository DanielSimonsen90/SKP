import { ChangeEvent, useEffect, useRef, useState } from "react";
import { Project } from "danhosaurportfolio-models";
import { BaseProps, Button, classNames, UseStateSetState, useDeepCompareEffect } from "danholibraryrjs";

import { useTranslate } from "providers/LanguageProvider";
import { useModal } from "providers/ModalProvider";

import LoadData from "components/shared/LoadData";
import { ButtonContainer, ImageContainer } from "components/shared/container/SpecificContainer";

import ProjectImageModal from "./ProjectImageModal";

export const ImageSrcPrefix = 'data:image/png;base64,';

type ProjectImageChangeableProps = {
    src: string,
    setSrc: UseStateSetState<string>,
    prefixSrc(value: string): string
}

function ProjectImageChangeable({ src = "", setSrc, prefixSrc }: ProjectImageChangeableProps) {
    const [image, setImage] = useState<string | ArrayBuffer | null>(src);
    const [loading, setLoading] = useState(false);
    const [file, setFile] = useState<File | null | undefined>(null);

    useDeepCompareEffect(() => { 
        if (image) {
            setSrc(prefixSrc(image.toString()));
        }
     }, [image]);
    useEffect(() => { 
        setLoading(file !== null && file !== undefined);
     }, [file]);

    const inputRef = useRef<HTMLInputElement>();
    const onChange = (e: ChangeEvent<HTMLInputElement>) => {
        e.stopPropagation();
        setFile(e.target.files?.[0]);
    };
    const loadData = () => new Promise(resolve => {
        const reader = new FileReader();
        reader.onload = () => {
            if (reader.readyState === 2) {
                setImage(reader.result);
                setLoading(false);
                resolve(reader.result);
            }
        }
        if (file) reader.readAsDataURL(file);
    });

    // TODO: Fixed in library update
    // @ts-ignore
    if (loading) return <LoadData loadData={loadData} />

    return (<>  
        {/* @ts-ignore -- For some reason inputRef should be null and not undefined */}
        <input ref={inputRef} style={{ display: 'none' }} type="file" id="project-image-change" onChange={onChange} onClick={e => e.stopPropagation()} />
        <ButtonContainer>
            <Button className="project-image-changeable" importance="secondary" crud="create" iconName="upload" onClick={e => {
                e.stopPropagation();
                e.preventDefault();
                inputRef.current?.click();
            }}>Upload</Button>
            <Button className="project-image-changeable" importance="secondary" crud="delete" onClick={e => {
                e.stopPropagation();
                e.preventDefault();
                setFile(null);
                setSrc("");
            }}>Clear</Button>
        </ButtonContainer>
    </>)
}

type Props = BaseProps<HTMLImageElement> & {
    project: Project,
    /**@default true */
    modalable?: boolean,
    /**@default false */
    changable?: boolean,

    src?: string,
    onSrcChange?: (value: string) => void
}
export default function ProjectImage({ project, src: baseSrc, onSrcChange, changable = false, modalable = true, className, ...props }: Props) {
    const translate = useTranslate();
    const prefixSrc = (value: string) => {
        const strVal = value && typeof value !== 'string' ? (value as any as Buffer).toString("base64") : value;
        return strVal && !strVal.includes(ImageSrcPrefix) ? `${ImageSrcPrefix}${value}` : value
    };
    const [src, setSrc] = useState(prefixSrc(baseSrc || project?.image || ""));
    const [toggleModal] = useModal(<ProjectImageModal project={project} src={src} />);

    useDeepCompareEffect(() => { onSrcChange?.(src); }, [src]);

    if (!src || src === prefixSrc('[object Object]')) return (
        <ImageContainer className={classNames('no-image', className)}>
            <p className="project-image">{translate('noImage')}</p>
            {changable ? <ProjectImageChangeable src={src} setSrc={setSrc} prefixSrc={prefixSrc} /> : null}
        </ImageContainer>
    );

    return (
        <ImageContainer className={className}>
            <img className={classNames('project-image', className)} src={src} 
                data-clickable={modalable} alt="Project preview" tabIndex={modalable ? 0 : -1}
                onClick={() => modalable && toggleModal('show')}
                onKeyDown={e => (e.key === 'Enter' || e.key === 'NumpadEnter') && modalable && toggleModal('show')}
                {...props} 
            />
            {changable ? <ProjectImageChangeable src={src} setSrc={setSrc} prefixSrc={prefixSrc} /> : null}
        </ImageContainer>
    )
}