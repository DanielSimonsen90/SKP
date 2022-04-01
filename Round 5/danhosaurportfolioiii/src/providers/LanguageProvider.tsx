import { createContext, useCallback, useContext } from 'react';
import { BaseProps, useLocalStorage, UseStateReturn } from 'danholibraryrjs';
import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import { FilterData } from 'sites/Projects/ProjectsContent';
import data from '../languages.json';
import { useSettings } from './SettingsProvider';

export type SupportedLanguages = 'Dansk' | 'English';
export type TranslationObj = Record<SupportedLanguages, any>
export type LanguagesObj = Record<'format' | 'unformat', Record<ProgrammingLanguage, string>>;
export type FilterObj = Record<keyof FilterData, Record<'title' | 'description', string>>;
export type FilterObjReverse = Record<string, keyof FilterData>;
type UseTranslateFiltersReturn<Reverse extends boolean> = Reverse extends false ? FilterObj : FilterObjReverse; 

const LanguageContext = createContext<UseStateReturn<SupportedLanguages>>(["English", () => {}]);

export function useLanguage() {
    return useContext(LanguageContext);
}
export function useTranslationObj(): TranslationObj {
    return data;
}
export function useTranslate<T = string>() {
    const [language] = useLanguage();
    return (key: string): T => (
        (data as TranslationObj)[language][key] || 
        key.substring(0, 1).toUpperCase() + key.substring(1)
    ) as T
}
export function useTranslateProgrammingLanguages() {
    return useTranslate<LanguagesObj>()("languages");
}
export function useTranslateFilters<Reverse extends boolean = false>(reverse: Reverse = false as Reverse): UseTranslateFiltersReturn<Reverse> {
    const filter = useTranslate<FilterObj>()("filters");
    if (!reverse) return filter as UseTranslateFiltersReturn<Reverse>;

    const values = Object.keys(filter);
    const props = Object.values(filter).map(v => v.title);
    return props.reduce((result, prop, i) => {
        result[prop] = values[i];
        return result;
    }, {}) as UseTranslateFiltersReturn<Reverse>
}
export function useLanguages(): Array<SupportedLanguages> {
    return Object.keys(data) as Array<SupportedLanguages>;
}

export default function LanguageProvider({ children }: BaseProps) {
    const [language, setLanguage] = useSettings("language");

    return (
        <LanguageContext.Provider value={[language, setLanguage]}>
            {children}
        </LanguageContext.Provider>
    )
}
