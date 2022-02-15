import { ProgrammingLanguage } from 'danhosaurportfolio-models';
import { useTranslateProgrammingLanguages } from 'providers/LanguageProvider';
import './ProgrammingLanguage.scss';

type Props = {
    language: ProgrammingLanguage
}

export default function ProjectLanguage({ language }: Props) {
    const translate = useTranslateProgrammingLanguages();
    const iconName = (translate.unformat[language.replace('.js', '')] || language.replace('.js', ''))?.toLowerCase();

    return (
        <span className="programming-language">
            <img className="icon" src={`Programming Languages/${iconName}.png`} alt={`${language} logo`} />
            {language.toString()}
        </span>
    );
}