import { Project } from "danhosaurportfolio-models";
import { PropertiesWith } from "danholibraryjs";
import { useMe } from "providers/MeProvider";

export default function useItemsFor(prop: keyof PropertiesWith<string, Project>) {
    const { projects } = useMe();
    return projects.reduce((result, proj) => {
        if (!result.includes(proj[prop]) && proj.display) result.push(proj[prop]);
        return result;
    }, new Array<string>()).sort();
}