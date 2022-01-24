import { useMemo, useRef } from 'react'
import { useHover } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import { useBookmarks } from 'providers/BookmarkProvider';
import { useTranslate } from 'providers/LanguageProvider';
import './Bookmark.scss'

type Props = {
    project: Project
}

export default function Bookmark({ project }: Props) {
    const { bookmarks, add, remove } = useBookmarks();
    const translate = useTranslate();
    const containerRef = useRef<HTMLDivElement>();
    const hovered = useHover(containerRef);
    const isBookmarked = useMemo(() => bookmarks.some(b => b.id === project._id), [bookmarks, project]);
    const title = `${translate('bookmark')} ${translate('project').toLowerCase()}`;

    const onClick = () => (isBookmarked ? remove : add)(project);

    return (
        <div className={`bookmark${isBookmarked ? ' bookmark-selected' : ''}${hovered ? ' bookmark-hovered' : ''}`} 
            ref={containerRef} 
            onClick={onClick} 
            title={title} 
        />
    )
}
