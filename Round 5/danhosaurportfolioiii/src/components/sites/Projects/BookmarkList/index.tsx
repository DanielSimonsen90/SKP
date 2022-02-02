import { useMemo } from 'react'
import { Container } from 'danholibraryrjs';
import { useBookmarks } from 'providers/BookmarkProvider'
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import Bookmark from '../Bookmark';
import './BookmarkList.scss';

export default function BookmarkList() {
    const { bookmarks } = useBookmarks();
    const { projects } = useMe();
    const translate = useTranslate();
    const bookmarkProjects = useMemo(() => projects.filter(p => bookmarks.some(b => b.id === p._id)), [bookmarks, projects])

    if (!bookmarkProjects.length) return null;

    return (
        <Container className='bookmark-list' type='flex'>
            <h1>{translate('bookmarks')}</h1>
            {bookmarks.map(bookmark => (
                <div className='bookmark-list-item' key={bookmark.id}>
                    <Bookmark project={bookmarkProjects.find(p => p._id === bookmark.id)} />
                    <LinkItem title={bookmark.name} link={`#${bookmark.name}`} />
                </div>
            ))}
        </Container>
    )
}
