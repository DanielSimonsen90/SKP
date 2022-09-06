import { Project } from "danhosaurportfolio-models";
import { PropertiesWith } from "danholibraryjs";
import { useMe } from "providers/MeProvider";
import { FilterData } from "components/sites/Projects/ProjectsContent";

export default function useItemsFor(prop: keyof PropertiesWith<string, Project>, filter?: FilterData) {
    const { projects } = useMe();
    return projects.reduce((result, proj) => {
        if (!result.includes(proj[prop]) && // @ts-ignore
            (filter ? Object.array(filter).every(([key, value]) => proj[key] === value) : true) &&
            proj.display
        ) result.push(proj[prop]);
        return result;
    }, new Array<string>()).sort();
}