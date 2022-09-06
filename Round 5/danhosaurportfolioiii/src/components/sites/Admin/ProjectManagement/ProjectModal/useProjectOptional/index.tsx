import { useMemo, useState } from "react";
import { Collab } from "danhosaurportfolio-models";
import { useStateUpdate } from 'danholibraryrjs';

import InfoContainer from "components/shared/container/InfoContainer";
import ProjectImage, { ImageSrcPrefix } from "components/sites/Projects/Project/ProjectImage";

import { ConstructableProps, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import { UseProjectInformationProps } from "../useProjectInformation";
import Input from "../Input";
import { useMe } from "providers/MeProvider";

export type UseProjectOptionalProps = Partial<Omit<ConstructableProps, keyof UseProjectInformationProps>>
export type UseProjectOptionalReturn = UseProjectModifyReturn<UseProjectOptionalProps>

const GITHUB_BASE_URL = "https://github.com";

export default function useProjectOptional({ project }: ProjectModalHookProps): UseProjectOptionalReturn {
    const me = useMe();

    const [isOnGithub, setIsOnGithub] = useState(project?.link.startsWith(GITHUB_BASE_URL) || false);
    const [isSpareTime, setisSpareTime] = useState(project?.spareTime || false);
    const [repoOwner, setRepoOwner] = useState<string>(project?.collab?.github ?? me.contact.github);
    const [repoPath, setRepoPath] = useState(!project?.link ? "" : project.link.replace(GITHUB_BASE_URL, "").split("/").slice(2).join("/"));
    const [image, setImage] = useState(project?.image || "")
    
    const collab = useMemo(() => repoOwner !== me.contact.github ? new Collab(repoOwner, repoPath) : undefined, [repoOwner, repoPath, me.contact.github]);
    const fullUrl = useMemo(() => {
        const baseUrl = isOnGithub ? `${GITHUB_BASE_URL}/${repoOwner}/` : "";
        return `${baseUrl}${repoPath}`;
    }, [isOnGithub, me.contact.github, repoOwner])
    const onImgSrcChanged = (value: string) => setImage(value.replace(ImageSrcPrefix, ''));

    const ProjectModalOptional = (
        <InfoContainer title="Optional">
            <div className="basic project-optional-row">
                <div className="checkboxes project-optional-row">
                    <Input title="On GitHub" type="checkbox" value={isOnGithub} onChange={setIsOnGithub} />
                    <Input title="Made in spare time" type="checkbox" value={isSpareTime} onChange={setisSpareTime} />
                </div>
                {!isOnGithub ? (
                    <div className="link project-optional-row">
                        <Input title="URL to project, if any" type="text" value={repoPath} onChange={setRepoPath} />
                    </div>
                ) : (
                <InfoContainer title="GitHub Repository" className="github-repo link project-optional-row">
                    <Input title="Owner" type="text" value={repoOwner} onChange={setRepoOwner} required />
                    <Input title="Repository" type="text" value={repoPath} onChange={setRepoPath} required />
                </InfoContainer>
                )}
            </div>
            { project ? <ProjectImage className="project-optional-row" project={project} changable={true} src={image} onSrcChange={onImgSrcChanged} /> : null }
        </InfoContainer>
    )

    const didChange = useStateUpdate(false, {
        before: () => {
            const value = (
                fullUrl !== project?.link ||
                isSpareTime !== project?.spareTime ||
                image !== project?.image ||
                project?.link?.includes(repoOwner) === false
            )
            return value;
        },
        // TODO: Remove when library is updated
        after() {}
    }, [fullUrl, isSpareTime, repoOwner, image]);

    return [ProjectModalOptional, didChange, {
        collab, image, link: repoPath,
        spareTime: isSpareTime, 
    }]
}