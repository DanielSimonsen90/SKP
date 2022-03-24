import { ProgrammingLanguage } from "danhosaurportfolio-models";
import { useLanguage, useTranslateProgrammingLanguages } from "providers/LanguageProvider";
import { useMemo } from "react";

export function useLanguageColor(language: ProgrammingLanguage, postfix?: string) {
    const [siteLang] = useLanguage()
    const translate = useTranslateProgrammingLanguages();
    const value = useMemo(() => {
        const value = translate.unformat[language] || language;
        return `var(--prgmLang-${value.toLowerCase().replaceAll('.', '')}${postfix ? `-${postfix}` : ''})`;
    }, [language, siteLang]);
    return value;
}