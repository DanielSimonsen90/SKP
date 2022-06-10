import { useMemo, useState } from "react";
import { Collab } from "danhosaurportfolio-models";
import { useStateOnUpdate } from 'danholibraryrjs';

import InfoContainer from "components/shared/container/InfoContainer";
import ProjectImage, { ImageSrcPrefix } from "components/sites/Projects/Project/ProjectImage";

import { ConstructableProps, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import { UseProjectInformationProps } from "../useProjectInformation";
import Label from "../Label";

export type UseProjectOptionalProps = Omit<ConstructableProps, keyof UseProjectInformationProps>
export type UseProjectOptionalReturn = UseProjectModifyReturn<UseProjectOptionalProps>

export default function useProjectOptional({ project }: ProjectModalHookProps): UseProjectOptionalReturn {
    const [baseLink, setBaseLink] = useState(project?.baseLink || "");
    const [isOnGithub, setIsOnGithub] = useState(project?.baseLink !== undefined);
    const [isSpareTime, setisSpareTime] = useState(project?.spareTime || false);
    const [collabGithub, setCollabGithub] = useState<string>(project?.collab?.github)
    const [collabRepo, setCollabRepo] = useState<string>(project?.collab?.repo);
    const [image, setImage] = useState(project?.image || "")

    const hasLink = useMemo(() => isOnGithub || baseLink !== "", [baseLink, isOnGithub]);
    const collab = useMemo(() => collabGithub || collabRepo ? new Collab(collabGithub, collabRepo) : null, [collabGithub, collabRepo]);
    const onImgSrcChanged = (value: string) => setImage(value.replace(ImageSrcPrefix, ''));

    const ProjectModalOptional = (
        <InfoContainer title="Optional">
            <div className="basic project-optional-row">
                <div className="base-link project-optional-row">
                    <Label title="Base path" type="text" value={baseLink} onChange={setBaseLink} />
                </div>
                <div className="checkboxes project-optional-row">
                    <Label title="Is on Github" type="checkbox" value={isOnGithub} onChange={setIsOnGithub} />
                    <Label title="Made in spare time" type="checkbox" value={isSpareTime} onChange={setisSpareTime} />
                </div>
            </div>
            <InfoContainer title="Collab" className="collab project-optional-row">
                <Label title="Collab" type="text" value={collabGithub} onChange={setCollabGithub} />
                <Label title="Collab repo" type="text" value={collabRepo} onChange={setCollabRepo} />
            </InfoContainer>
            <ProjectImage className="project-optional-row" project={project} changable={true} src={image} onSrcChange={onImgSrcChanged} />
        </InfoContainer>
    )

    const didChange = useStateOnUpdate(false, () => {
        const value = (
            baseLink !== project?.baseLink ||
            isOnGithub !== (project?.baseLink !== undefined) ||
            isSpareTime !== project?.spareTime ||
            collabGithub !== project?.collab?.github ||
            collabRepo !== project?.collab?.repo ||
            image !== project?.image
        )
        console.log({
            state: { baseLink, isOnGithub, isSpareTime, collabGithub, collabRepo, image },
            props: { 
                baseLink: project?.baseLink, 
                isOnGithub: project?.baseLink !== undefined, 
                spareTime: project?.spareTime, 
                collabGithub: project?.collab?.github, 
                collabRepo: project?.collab?.repo, 
                image: project?.image 
            },
            value
        })
        return value;
    }, [baseLink, hasLink, isSpareTime, collabGithub, collabRepo, image]);

    return [ProjectModalOptional, didChange, {
        collab, image, hasLink,
        spareTime: isSpareTime, 
        baseLink: baseLink
    }]
}