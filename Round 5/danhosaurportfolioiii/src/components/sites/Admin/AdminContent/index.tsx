import { createRoute, Router, useRedirect } from 'danholibraryrjs';
import { useAdmin } from 'providers/AdminProvider';
import Navbar from 'components/shared/navigation/Navbar';
import AdminDashboard from '../AdminDashboard';
import Login from '../Login';
import Management from '../Management';
import ProjectManagement from '../ProjectManagement';
import './AdminContent.scss';

export default function AdminContent() {
    const { setAdmin, isAdmin } = useAdmin();
    const redirect = useRedirect();
    const routes = [
        createRoute('admin/management', Management),
        createRoute('admin/projects', ProjectManagement),
        createRoute('admin', AdminDashboard)
    ]

    const logout = () => {
        setAdmin(null);
        redirect('admin');
    }

    if (!isAdmin) return <Login />

    return (
        <div id='admin-content'>
            <Navbar routes={routes} includeLogo={false}>
                <button onClick={() => logout()}>Logout</button>
            </Navbar>
            <Router routes={routes} fallback={AdminDashboard} />
        </div>
    )
}
