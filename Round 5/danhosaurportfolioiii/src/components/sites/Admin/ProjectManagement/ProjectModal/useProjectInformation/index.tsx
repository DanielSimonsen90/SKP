import { useMemo, useState } from "react";
import { DanhoDate, IProgrammingLanguage, ProgrammingLanguage } from "danhosaurportfolio-models";
import { useStateUpdate } from "danholibraryrjs";
import { BetterOmit } from "danholibraryjs";

import InfoContainer from "components/shared/container/InfoContainer";
import FilterInputList from "components/sites/Projects/ProjectFilter/FilterInputList";

import { ConstructableProps, ProjectModalHookProps, UseProjectModifyReturn } from "..";
import Label from "../Input";
import DescriptionInput from "./DescriptionInput";

type ProjectType = IProgrammingLanguage[ProgrammingLanguage];
export type UseProjectInformationProps = BetterOmit<ConstructableProps, 
    'collab' | 'image' | 'spareTime' | 'link'
>

export default function useProjectInformation({ project }: ProjectModalHookProps): UseProjectModifyReturn<UseProjectInformationProps> {
    const [name, setName] = useState(project?.name || "")
    const [display, setDisplay] = useState(project?.display || false)
    const [language, setLanguage] = useState<ProgrammingLanguage>(project?.language || "" as ProgrammingLanguage)
    const [projectType, setProjectType] = useState<ProjectType>(project?.projectType || "" as ProjectType)
    const [createdAtTimestamp, setCreatedAtTimestamp] = useState(project?.createdAt.getTime() || Date.now())
    const createdAt = useMemo(() => {
        const date = new Date(createdAtTimestamp);
        return new DanhoDate(date.getFullYear(), date.getMonth() + 1, date.getDate())
    }, [createdAtTimestamp]);
    const [dansk, setDansk] = useState(project?.description.Dansk || new Array<string>());
    const [english, setEnglish] = useState(project?.description.English || new Array<string>());

    const ProjectModalInformation = (
        <InfoContainer title="Project Information">
            <div className='name-display project-information-row'>
                <Label title="Name" type="text" value={name} onChange={setName} required={true} />
                <Label title="Display" type="checkbox" value={display} onChange={setDisplay} />
                <Label title="Created at" type="date" value={createdAt.toStringReverse()} onChange={s => 
                    setCreatedAtTimestamp(new Date(
                        typeof s === 'function' ? s(createdAt.toString()) : s
                    ).getTime())} 
                    required={true}
                />
            </div>
            <div className='language-project project-information-row'>
                <FilterInputList type='language' value={language} onChange={lang => setLanguage(lang as ProgrammingLanguage)} required={true} />
                <FilterInputList type='projectType' value={projectType} onChange={type => setProjectType(type as ProjectType)} required={true} />
            </div>
            <div className="description project-information-row">
                <DescriptionInput title="Description: Dansk" value={dansk.join('\n')} onChange={s => setDansk(typeof s === 'function' ? s(dansk.join('\n')).split('\n') : s.split('\n'))} />
                <DescriptionInput title="Description: English" value={english.join('\n')} onChange={s => setEnglish(typeof s === 'function' ? s(english.join('\n')).split('\n') : s.split('\n'))} />
            </div>
        </InfoContainer>
    )

    const didChange = useStateUpdate(false, {
        after: () => {}, // TODO: Remove once library is updated
        before: () => {
            if (!project) return true;

            return (
                project.name !== name || 
                project.display !== display ||
                project.language !== language ||
                project.projectType !== projectType ||
                project.createdAt.getTime() !== createdAtTimestamp ||
                project.description.Dansk.some((sentence, i) => dansk[i] !== sentence) || 
                project.description.English.some((sentence, i) => english[i] !== sentence)
            )
        } 
    }, [name, display, language, projectType, createdAtTimestamp, dansk, english]);

    return [ProjectModalInformation, didChange, {
        name, display, language, projectType, createdAt, 
        description: {
            Dansk: dansk, 
            English: english
        }
    }]
}
