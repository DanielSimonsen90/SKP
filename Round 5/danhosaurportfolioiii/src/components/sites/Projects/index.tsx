import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useMe, useSetProjects } from 'providers/MeProvider'
import LoadData from 'components/shared/LoadData';
import ProjectsContent from './ProjectsContent';
import './Projects.scss'

export type LanguageFilter = ProgrammingLanguage | 'all';

export default function Projects() {
    const me = useMe();
    const setProjects = useSetProjects();
    // TODO: Remove function when library is updated
    const Content = () => <ProjectsContent />

    return !me.projects.length ? (
        <>
            {/* @ts-ignore */}
            <LoadData loadData={setProjects} valueComponent={Content}/>
        </>
    ) : <Content />
    
}
