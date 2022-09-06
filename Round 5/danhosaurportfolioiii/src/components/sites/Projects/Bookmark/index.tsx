import { useMemo } from 'react'
import Icon from 'react-fontawesome';

import { Project } from 'danhosaurportfolio-models';
import { ClickEvent, useAnimation } from 'danholibraryrjs';
import { GetCSSProperty } from 'danholibraryjs';

import { useBookmarks } from 'providers/BookmarkProvider';
import { useTranslate } from 'providers/LanguageProvider';

import './Bookmark.scss'

type Props = {
    project: Project,
    className?: string
}

export default function Bookmark({ className, project }: Props) {
    const translate = useTranslate();
    const { bookmarks, add, remove } = useBookmarks();
    const isBookmarked = useMemo(() => bookmarks.some(b => b.id === project._id), [bookmarks, project]);
    const title = `${translate('bookmark')} ${translate('project').toLowerCase()}`;
    const animate = useAnimation(`span[data-project="${project._id}"]`, 'animation-reverse', GetCSSProperty('--animation-time', 'number'))

    const onClick = (e: ClickEvent) => {
        e.stopPropagation();
        return (isBookmarked ? animate().then(() => remove(project)) : add(project));
    };

    return (
        <Icon name='bookmark' title={title} onClick={onClick} 
            className={`bookmark${isBookmarked ? ' bookmark-selected' : ''}${className ? ` ${className}` : ''}`} 
            data-project={project._id}
        />
    )
}
