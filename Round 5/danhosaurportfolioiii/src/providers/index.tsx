import { BaseProps } from 'danholibraryrjs'
import BookmarksProvider from './BookmarkProvider'
import LanguageProvider from './LanguageProvider'
import MeProvider from './MeProvider'
import ModalProvider from './ModalProvider'
import RouteProvider from './RouteProvider'

export default function Providers({ children }: BaseProps) {
    return (
        <LanguageProvider>
        <MeProvider>
        <BookmarksProvider>
        <RouteProvider>
        <ModalProvider>
            {children}
        </ModalProvider>
        </RouteProvider>
        </BookmarksProvider>
        </MeProvider>
        </LanguageProvider>
    )
}