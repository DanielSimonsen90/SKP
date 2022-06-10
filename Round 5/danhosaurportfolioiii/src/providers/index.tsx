import { BaseProps } from 'danholibraryrjs';
import AdminProvider from './AdminProvider';
import BookmarksProvider from './BookmarkProvider';
import MeProvider from './MeProvider';
import ModalProvider from './ModalProvider';
import RouteProvider from './RouteProvider';
import SettingsProvider from './SettingsProvider';

export default function Providers({ children }: BaseProps) {
    return (
        <SettingsProvider>
        <AdminProvider>
        <MeProvider>
        <BookmarksProvider>
        <RouteProvider>
        <ModalProvider>
            {children}
        </ModalProvider>
        </RouteProvider>
        </BookmarksProvider>
        </MeProvider>
        </AdminProvider>
        </SettingsProvider>
    )
}
