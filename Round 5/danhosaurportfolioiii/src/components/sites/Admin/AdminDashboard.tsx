import { useAdmin } from 'providers/AdminProvider'

export default function AdminDashboard() {
    const { admin } = useAdmin();
    
    return (
        <div id='admin-dashboard'>
            <h1>Greetings, {admin.username}!</h1>
        </div>
    )
}
