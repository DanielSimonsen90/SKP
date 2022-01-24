import { useEffect } from 'react'
import { useStateOnChange } from 'danholibraryrjs';
import { SupportedLanguages, useLanguage, useLanguages, useTranslate } from 'providers/LanguageProvider'
import './LanguageSelector.scss';

export default function LanguageSelector() {
    const translate = useTranslate();
    const [currentLanguage, setLanguage] = useLanguage();
    const [language, inputLanguage, setInput] = useStateOnChange(currentLanguage, 100);
    const languages = useLanguages();

    useEffect(() => {
        if (!languages.includes(language)) return;
        setLanguage(language);
    }, [language])

    return (
        <label id="language-selector">
            <p>{translate('language')}</p>
            <input type="text" value={inputLanguage} list='language-list' onChange={e => setInput(e.target.value as SupportedLanguages)}/>
            <datalist id='language-list'>
                {languages.map(lang => <option value={lang} key={lang} />)}
            </datalist>
        </label>
    )
}
