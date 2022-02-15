import { createContext, useContext, useState } from 'react'
import { BaseProps, UseStateReturn } from 'danholibraryrjs';
import { LocationCollection, Me, API, Item, Project } from 'danhosaurportfolio-models'
import { useTranslate } from './LanguageProvider';
import myData from '../me.json'

export const { email, github, phone, linkedin } = myData;
export const dummySpareTime = ["Discord", "Overwatch", "FruityLoops Studio"].map(activity => new Item(activity, [activity]));
export const api = new API("localhost:8081", github);
const locationCollection = new LocationCollection();
const contact = { email, phone, github, linkedin };
const dummyMe = new Me(locationCollection, contact, dummySpareTime, api);

const MeContext = createContext<UseStateReturn<Me>>([dummyMe, () => {}])

export function useMyState() {
    return useContext(MeContext);
}
export function useMe() {
    return useMyState()[0]
}
export function useLocationCollection() {
    return locationCollection;
}

export function useSetSpareTime() {
    const [me, setMe] = useMyState();
    const translate = useTranslate<Record<'discord' | 'overwatch' | 'flstudio', Array<string>>>();
    const spareTimeDescriptions = translate('spareTime');
    const description = (name: string) => spareTimeDescriptions[name.replaceAll(' ', '').toLowerCase()] as Array<string>;

    return () => {
        if (dummySpareTime[0].description !== me.spareTime[0].description) return;

        setMe(me => ({ ...me,
            spareTime: dummySpareTime.map(({ name }) => new Item(name, description(name)))
        }) as Me)
    }
}
export function useSetProjects() {
    const [me, setMe] = useMyState();

    return async (force = false) => {
        if (me.projects.length && !force) return me.projects;

        return dummyMe.projects.fetchProjects().then(projects => {
            setMe(me => ({ ...me, projects }) as Me);
            return projects;
        })
    }
}

export function useUpsertProject() {
    const { projects } = useMe();
    const setProjects = useSetProjects();

    return (project: Project) => (!projects.some(p => p._id === project._id) ? 
        api.create('projects', project) : 
        api.update('projects', project)).then(() => setProjects(true))
}

export default function MeProvider({ children }: BaseProps) {
    const [me, setMe] = useState(dummyMe);
    
    return (
        <MeContext.Provider value={[me, setMe]}>
            {children}
        </MeContext.Provider>
    )
}
