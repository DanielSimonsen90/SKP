import { useMemo } from 'react';
import { useLanguage, useTranslateFilters } from 'providers/LanguageProvider';
import { FilterProps } from 'components/sites/Projects/ProjectsContent';
import './FilterMenuOption.scss';

export type OnFilterMenuOptionClick = (title: string) => void;
type Props = {
    optionFor: keyof FilterProps['filter']
    onClick: OnFilterMenuOptionClick
}

export default function FilterMenuOption({ optionFor, onClick }: Props) {
    const language = useLanguage();
    const translate = useTranslateFilters();
    const title = useMemo(() => translate[optionFor].title, [optionFor, language]);
    const description = useMemo(() => translate[optionFor].description, [optionFor, language]);

    return (
        <li className='filter-menu-option' onClick={() => onClick(title)}>
            <span className="title">{title}:</span>
            <span className="description">{description}</span>
        </li>
    );
}