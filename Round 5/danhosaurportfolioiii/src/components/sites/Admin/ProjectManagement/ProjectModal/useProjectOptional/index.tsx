import { useMemo, useState } from "react";
import { useStateOnUpdate } from 'danholibraryrjs'
import { Collab } from "danhosaurportfolio-models";
import InfoContainer from "components/shared/container/InfoContainer";
import ProjectImage, { ImageSrcPrefix } from "components/sites/Projects/Project/ProjectImage";
import { ConstructableProps, Omid, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import { UseProjectInformationProps } from "../useProjectInformation";
import Label from "../Label";

export type UseProjectOptionalProps = Omid<ConstructableProps, keyof UseProjectInformationProps>
export type UseProjectOptionalReturn = UseProjectModifyReturn<UseProjectOptionalProps>

export default function useProjectOptional({ project }: ProjectModalHookProps): UseProjectOptionalReturn {
    const [basePath, setBasePath] = useState("");
    const [isOnGithub, setIsOnGithub] = useState(false);
    const [isSpareTime, setisSpareTime] = useState(project?.spareTime || false);
    const [collabGithub, setCollabGithub] = useState("")
    const [collabRepo, setCollabRepo] = useState("");
    const [image, setImage] = useState(project?.image || "")
    
    const didChange = useStateOnUpdate(false, () => true, [basePath, isOnGithub, isSpareTime, collabGithub, collabRepo, image]);
    const hasLink = useStateOnUpdate(false, state => {
        if (hasLink || isOnGithub || basePath) return hasLink;
        return state;
    }, [basePath, isOnGithub])

    const collab = useMemo(() => collabGithub || collabRepo ? 
        new Collab(collabGithub, collabRepo) : null, 
    [collabGithub, collabRepo]);

    const onImgSrcChanged = (value: string) => setImage(value.replace(ImageSrcPrefix, ''));

    const component = (
        <InfoContainer title="Optional">
            <div className="base-link project-optional-row">
                <Label title="Base path" type="text" value={basePath} onChange={setBasePath} />
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
        baseLink: basePath
    }]
}