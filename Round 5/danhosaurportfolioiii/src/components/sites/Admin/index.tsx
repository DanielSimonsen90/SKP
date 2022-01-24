import AdminProvider from 'providers/AdminProvider'
import AdminContent from './AdminContent'

export default function Admin() {
    return (
        <div id="admin-page">
            <AdminProvider>
                <AdminContent/>
            </AdminProvider>
        </div>
    )
}
