import { useEffect, useMemo, useState } from "react";
import { DanhoDate, IProgrammingLanguage, ProgrammingLanguage } from "danhosaurportfolio-models";
import InfoContainer from "components/shared/container/InfoContainer";
import FilterLabel from "components/sites/Projects/FilterLabel";
import DescriptionInput, { useDescription } from "./DescriptionInput";
import { ConstructableProps, Omid, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import Label from "../Label";

type ProjectType = IProgrammingLanguage[ProgrammingLanguage];
export type UseProjectInformationProps = Omid<ConstructableProps, 
    'collab' | 'image' | 'spareTime' | 'baseLink' | 'hasLink'
>

export default function useProjectInformation({ project }: ProjectModalHookProps): UseProjectModifyReturn<UseProjectInformationProps> {
    const [name, setName] = useState(project?.name || "")
    const [display, setDisplay] = useState(project?.display || false)
    const [language, setLanguage] = useState<ProgrammingLanguage>(project?.language || "" as ProgrammingLanguage)
    const [projectType, setProjectType] = useState<ProjectType>(project?.projectType || "" as ProjectType)
    const [createdAtTimestamp, setCreatedAtTimestamp] = useState(project?.createdAt.getTime() || Date.now())
    const createdAt = useMemo(() => {
        const date = new Date(createdAtTimestamp);
        return new DanhoDate(date.getFullYear(), date.getMonth(), date.getDate())
    }, [createdAtTimestamp]);
    const { dansk, setDansk, english, setEnglish } = useDescription(project?.description);
    const [didChange, setDidChange] = useState(false);

    const component = (
        <InfoContainer title="Project Information">
            <div className='name-display project-information-row'>
                <Label title="Name" type="text" value={name} onChange={setName} />
                <Label title="Display" type="checkbox" value={display} onChange={setDisplay} />
                <Label title="Created at" type="date" value={createdAt.toStringReverse()} onChange={s => setCreatedAtTimestamp(new Date(typeof s === 'function' ? s(createdAt.toString()) : s).getTime())} />
            </div>
            <div className='language-project project-information-row'>
                <FilterLabel type='language' value={language} onChange={lang => setLanguage(lang as ProgrammingLanguage)} />
                <FilterLabel type='projectType' value={projectType} onChange={type => setProjectType(type as ProjectType)} />
            </div>
            <div className="description project-information-row">
                <DescriptionInput title="Description: Dansk" value={dansk.join('\n')} onChange={s => setDansk(typeof s === 'function' ? s(dansk.join('\n')).split('\n') : s.split('\n'))} />
                <DescriptionInput title="Description: English" value={english.join('\n')} onChange={s => setEnglish(typeof s === 'function' ? s(english.join('\n')).split('\n') : s.split('\n'))} />
            </div>
        </InfoContainer>
    )

    useEffect(() => {
        if (!didChange) setDidChange(true);
    }, [name, display, language, projectType, createdAtTimestamp, dansk, english])

    return [component, didChange, {
        name, display, language, projectType, createdAt, 
        description: {
            Dansk: dansk, 
            English: english
        }
    }]
}
