import AdminProvider from 'providers/AdminProvider'
import AdminContent from './AdminContent'

export default function Admin() {
    return (
        <main id="admin-page">
            <AdminProvider>
                <AdminContent />
            </AdminProvider>
        </main>
    )
}
