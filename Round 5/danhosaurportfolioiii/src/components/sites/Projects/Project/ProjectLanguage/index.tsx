import { useMediaQuery } from 'danholibraryrjs';
import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useTranslateProgrammingLanguages } from 'providers/LanguageProvider';
import './ProjectLanguage.scss';

type Props = {
    language: ProgrammingLanguage
}

export default function ProjectLanguage({ language }: Props) {
    const translate = useTranslateProgrammingLanguages();
    const iconName = (translate.unformat[language.replace('.js', '')] || language.replace('.js', ''))?.toLowerCase();
    const isNano = useMediaQuery("300");

    return (
        <span className="programming-language">
            <img className="icon" src={`/Programming Languages/${iconName}.png`} alt={`${language} logo`} />
            {!isNano && language.toString()}
        </span>
    );
}