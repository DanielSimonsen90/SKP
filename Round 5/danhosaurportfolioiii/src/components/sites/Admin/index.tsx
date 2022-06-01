import { Button, createRoute, Router } from 'danholibraryrjs';
import { useAdmin } from 'providers/AdminProvider';
import Navbar from 'components/shared/navigation/Navbar';
import AdminDashboard from './AdminDashboard';
import Login from './Login';
import Management from './Management';
import ProjectManagement from './ProjectManagement';
import './Admin.scss';

export default function AdminContent() {
    const { setAdmin, isAdmin } = useAdmin();
    const routes = [
        createRoute('admin/management', Management),
        createRoute('admin/projects', ProjectManagement),
        createRoute('admin', AdminDashboard)
    ]

    return (
        <main className='admin-page'>
            {!isAdmin ? 
                <Login /> : 
                <>
                    <Navbar routes={routes} includeLogo={false} className='admin-nav'>
                        <Button importance='tertiary' crud="delete" iconName='sign-out' onClick={() => setAdmin(null)} value='Logout' />
                    </Navbar>
                    <Router routes={routes} fallback={AdminDashboard} />
                </>
            }
        </main>
    )
}
