import { createContext, useContext } from 'react';
import { BaseProps, useLocalStorage } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';

type Bookmark = Pick<Project,'name'> & {
    id: number
};
type BookmarkManager = {
    bookmarks: Array<Bookmark>,
    add: (project: Project) => Array<Bookmark>,
    remove: (project: Project) => Array<Bookmark>,
}

const BookmarksContext = createContext<BookmarkManager>({
    bookmarks: new Array<Bookmark>(),
    add: () => null,
    remove: () => null
});

export function useBookmarks() {
    return useContext(BookmarksContext)
}


export default function BookmarksProvider({ children }: BaseProps) {
    const [bookmarks, setBookmarks] = useLocalStorage('bookmarks', new Array<Bookmark>());

    const toBookMark = (project: Project): Bookmark => ({
        id: project._id,
        name: project.name
    })

    const add = (project: Project) => {
        setBookmarks(arr => [...arr, toBookMark(project)]);
        return bookmarks;
    }
    const remove = (project: Project) => {
        setBookmarks(arr => arr.filter(bookmark => bookmark.id !== project._id));
        return bookmarks;
    }

    const value: BookmarkManager = {
        bookmarks, add, remove
    }

    return (
        <BookmarksContext.Provider value={value}>
            {children}
        </BookmarksContext.Provider>
    );
}