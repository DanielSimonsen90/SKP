import { createContext, useContext } from 'react';
import { BaseProps, useLocalStorage, UseStateReturn } from 'danholibraryrjs';
import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import data from '../languages.json';

export type SupportedLanguages = 'Dansk' | 'English';
export type TranslationObj = Record<SupportedLanguages, any>
export type LanguagesObj = Record<'format' | 'unformat', Record<ProgrammingLanguage, string>>;

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
export function useLanguages(): Array<SupportedLanguages> {
    return Object.keys(data) as Array<SupportedLanguages>;
}

export default function LanguageProvider({ children }: BaseProps) {
    const [language, setLanguage] = useLocalStorage<"language", SupportedLanguages>("language", "English");

    return (
        <LanguageContext.Provider value={[language, setLanguage]}>
            {children}
        </LanguageContext.Provider>
    )
}
