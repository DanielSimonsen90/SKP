import { useMemo, useState } from "react";
import { useStateOnUpdate } from 'danholibraryrjs'
import { Collab } from "danhosaurportfolio-models";
import InfoContainer from "components/shared/container/InfoContainer";
import { ImageContainer } from "components/shared/container/SpecificContainer";
import { ConstructableProps, Omid, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import { UseProjectInformationProps } from "../useProjectInformation";
import Label from "../Label";
import ProjectImage from "components/sites/Projects/Project/ProjectImage";

export type UseProjectOptionalProps = Omid<ConstructableProps, keyof UseProjectInformationProps>
export type UseProjectOptionalReturn = UseProjectModifyReturn<UseProjectOptionalProps>

export default function useProjectOptional({ project }: ProjectModalHookProps): UseProjectOptionalReturn {
    const [basePath, setBasePath] = useState("");
    const [isOnGithub, setIsOnGithub] = useState(false);
    const [isSpareTime, setisSpareTime] = useState(project?.spareTime || false);
    const [collabGithub, setCollabGithub] = useState("")
    const [collabRepo, setCollabRepo] = useState("");
    const [imagePath, setImagePath] = useState(project?.image.toString("base64") || "")
    
    const didChange = useStateOnUpdate(false, () => true, [basePath, isOnGithub, isSpareTime, collabGithub, collabRepo, imagePath]);
    const hasLink = useStateOnUpdate(false, state => {
        if (hasLink || isOnGithub || basePath) return hasLink;
        return state;
    }, [basePath, isOnGithub])

    const collab = useMemo(() => new Collab(collabGithub, collabRepo), [collabGithub, collabRepo]);
    // const image = useMemo(() => {
    //     const reader = new FileReader();
    //     return Buffer.from(null)
    // }, [imagePath])

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
            <InfoContainer title="Project Image" className="project-image project-optional-row">
                {/* <ImageContainer className="project-image project-optional-row">
                    <img src={`data:image/png;base64,${imagePath}`} alt="Project preview" />
                </ImageContainer> */}
                <ProjectImage project={project} />
            </InfoContainer>
        </InfoContainer>
    )

    return [component, didChange, {
        collab, image: null, hasLink,
        spareTime: isSpareTime, 
        baseLink: basePath
    }]
}