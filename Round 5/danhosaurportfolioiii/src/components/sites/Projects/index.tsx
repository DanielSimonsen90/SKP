import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useMe, useSetProjects } from 'providers/MeProvider'
import LoadData from 'components/shared/LoadData';
import ProjectsContent from './ProjectsContent';
import './Projects.scss'

export type LanguageFilter = ProgrammingLanguage | 'all';

export default function Projects() {
    const me = useMe();
    const setProjects = useSetProjects();
    const valueComponent = <ProjectsContent />

    return !me.projects.length ? (
        <LoadData loadData={setProjects} valueComponent={valueComponent}/>
    ) : valueComponent
    
}
