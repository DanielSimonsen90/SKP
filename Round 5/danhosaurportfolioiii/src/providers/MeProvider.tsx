import { createContext, useContext, useEffect, useState } from 'react'
import { LocationCollection, ProjectCollection, Me, API, Item, Project } from 'danhosaurportfolio-models';
import { BaseProps, useSessionStorage, UseStateReturn } from 'danholibraryrjs';
import { useTranslate } from './LanguageProvider';
import myData from '../me.json'
import { DanhoDate } from 'danhosaurportfolio-models';

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
    const setProjects = (projects: ProjectCollection) => setMe(me => ({ ...me, projects }) as Me);
    const [value, setValue, removeValue] = useSessionStorage('projects', new ProjectCollection(api), data => {
        const result = new ProjectCollection(api);
        
        for (const entry of data) {
            const item = new Project(entry.name, {
                ...entry,
                githubUsername: github,
                createdAt: new DanhoDate(entry.createdAt.year, entry.createdAt.month, entry.createdAt.day),
                hasLink: entry.link && true
            })
            result.add({...entry, ...item} as Project)
        }
        return result;
    })

    useEffect(() => {
        setValue(v => me.projects.length ? me.projects : v);
        return removeValue;
    }, [me, me.projects]);

    return async (force = false) => {
        if (!force) {
            if (me.projects.length) return me.projects;
            else if (value.length) {
                setProjects(value);
                return value;
            }
        }

        const projects = await dummyMe.projects.fetchProjects();
        setValue(projects);
        setProjects(projects);
        return projects;
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
