import { useEffect } from "react";
import { UseStateSetState } from "danholibraryrjs";
import { useTranslateFilters } from "providers/LanguageProvider";
import { FilterData } from "components/sites/Projects/ProjectsContent";

export default function useNewFilter(value: string, setFilter: UseStateSetState<FilterData>) {
    const translateReverse = useTranslateFilters(true);

    useEffect(() => {
        const split = value.split(':');
        const newFilter = split.reduce((result, item, i) => {
            if (item === '') return result;
            
            if (i % 2 !== 0 && i !== 0) {
                const key = translateReverse[split[i - 1]];
                // @ts-ignore
                result[key as any] = item.replace('_', ' ');

                const dateRegex = /^(?<day>0?[1-9]|[12]\d|3[01])\/(?<month>0?[1-9]|1[0-2])\/(?<year>19|20\d{2})$/;
                if (dateRegex.test(item)) {
                    // @ts-ignore
                    const { groups: { day, month, year }} = dateRegex.exec(item);
                    const [y, m, d] = [year, month, day].map(s => parseInt(s));
                    // @ts-ignore
                    result[key as any] = new Date(y, m - 1, d);
                }
            }
            // @ts-ignore
            else result[translateReverse[item] as any] = null;

            return result;
        }, {} as FilterData);
        
        // @ts-ignore
        if (Object.values(newFilter).includes(null)) return;
        
        setFilter(newFilter);
    }, [value])
}