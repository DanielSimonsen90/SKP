import { useMemo, useState } from "react";
import { Collab } from "danhosaurportfolio-models";
import { useStateOnUpdate } from 'danholibraryrjs';
import { BetterOmit } from "danholibraryjs";
import InfoContainer from "components/shared/container/InfoContainer";
import ProjectImage, { ImageSrcPrefix } from "components/sites/Projects/Project/ProjectImage";
import { ConstructableProps, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import { UseProjectInformationProps } from "../useProjectInformation";
import Label from "../Label";

export type UseProjectOptionalProps = BetterOmit<ConstructableProps, keyof UseProjectInformationProps>
export type UseProjectOptionalReturn = UseProjectModifyReturn<UseProjectOptionalProps>

export default function useProjectOptional({ project }: ProjectModalHookProps): UseProjectOptionalReturn {
    const [baseLink, setBaseLink] = useState(project?.baseLink || "");
    const [isOnGithub, setIsOnGithub] = useState(project?.baseLink !== undefined);
    const [isSpareTime, setisSpareTime] = useState(project?.spareTime || false);
    const [collabGithub, setCollabGithub] = useState(project?.collab?.github || "")
    const [collabRepo, setCollabRepo] = useState(project?.collab?.repo || "");
    const [image, setImage] = useState(project?.image || "")
    
    const didChange = useStateOnUpdate(false, () => true, [baseLink, isOnGithub, isSpareTime, collabGithub, collabRepo, image]);
    const hasLink = useStateOnUpdate(isOnGithub || baseLink !== "", () => hasLink || isOnGithub || baseLink !== "", [baseLink, isOnGithub])

    const collab = useMemo(() => collabGithub || collabRepo ? 
        new Collab(collabGithub, collabRepo) : null, 
    [collabGithub, collabRepo]);

    const onImgSrcChanged = (value: string) => setImage(value.replace(ImageSrcPrefix, ''));

    const component = (
        <InfoContainer title="Optional">
            <div className="base-link project-optional-row">
                <Label title="Base path" type="text" value={baseLink} onChange={setBaseLink} />
            </div>
            <div className="checkboxes project-optional-row">
                <Label title="Is on Github" type="checkbox" value={isOnGithub} onChange={setIsOnGithub} />
                <Label title="Made in spare time" type="checkbox" value={isSpareTime} onChange={setisSpareTime} />
            </div>
            <InfoContainer title="Collab" className="collab project-optional-row">
                <Label title="Collab" type="text" value={collabGithub} onChange={setCollabGithub} />
                <Label title="Collab repo" type="text" value={collabRepo} onChange={setCollabRepo} />
            </InfoContainer>
            <ProjectImage project={project} changable={true} onSrcChange={onImgSrcChanged} />
        </InfoContainer>
    )

    return [component, didChange, {
        collab, image, hasLink,
        spareTime: isSpareTime, 
        baseLink: baseLink
    }]
}