import { useMemo } from 'react'
import { BaseProps, Container } from 'danholibraryrjs';
import { useBookmarks } from 'providers/BookmarkProvider'
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import Bookmark from '../Bookmark';
import './BookmarkList.scss';

type Props = Pick<BaseProps, 'onClick'>;

export default function BookmarkList({ onClick }: Props) {
    const { bookmarks } = useBookmarks();
    const { projects } = useMe();
    const translate = useTranslate();
    const bookmarkProjects = useMemo(() => projects.filter(p => bookmarks.some(b => b.id === p._id)), [bookmarks, projects])

    if (!bookmarkProjects.length) return null;

    return (
        <Container className='bookmark-list' type='flex' onClick={onClick}>
            <h1>{translate('bookmarks')}</h1>
            {bookmarks.map(bookmark => (
                <div className='bookmark-list-item' key={bookmark.id}>
                    <Bookmark project={bookmarkProjects.find(p => p._id === bookmark.id)!} />
                    <LinkItem title={bookmark.name} link={`#${bookmark.name}`} />
                </div>
            ))}
        </Container>
    )
}
