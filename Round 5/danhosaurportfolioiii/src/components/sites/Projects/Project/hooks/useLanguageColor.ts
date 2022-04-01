import { ProgrammingLanguage } from "danhosaurportfolio-models";
import { useLanguage, useTranslateProgrammingLanguages } from "providers/LanguageProvider";
import { useMemo } from "react";

export function useLanguageColor(language: ProgrammingLanguage, suffix?: string) {
    const [siteLang] = useLanguage()
    const translate = useTranslateProgrammingLanguages();
    const value = useMemo(() => {
        const value = translate.unformat[language] || language;
        return `var(--prgmLang-${value.toLowerCase().replaceAll('.', '')}${suffix ? `-${suffix}` : ''})`;
    }, [language, siteLang]);
    return value;
}