import { UseStateSetState } from "danholibraryrjs";
import { useTranslateFilters } from "providers/LanguageProvider";
import { useEffect } from "react";
import { FilterData } from "sites/Projects/ProjectsContent";

export default function useNewFilter(value: string, setFilter: UseStateSetState<FilterData>) {
    const translateReverse = useTranslateFilters(true);

    useEffect(() => {
        const split = value.split(':');
        const newFilter = split.reduce((result, item, i) => {
            if (item !== '') {
                if (i % 2 === 0 || i === 0) result[translateReverse[item] as any] = null;
                else result[translateReverse[split[i - 1]] as any] = item;
            }

            return result;
        }, {} as FilterData);
        
        if (Object.values(newFilter).includes(null)) return;
        
        setFilter(newFilter);
    }, [value])
}