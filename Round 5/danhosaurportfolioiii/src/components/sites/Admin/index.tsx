import { useRoutes, BrowserRouter, Route, Routes } from 'react-router-dom';
import { Button } from 'danholibraryrjs';

import { useAdmin } from 'providers/AdminProvider';

import Navbar from 'components/shared/navigation/Navbar';

import AdminDashboard from './AdminDashboard';
import Login from './Login';
import Management from './Management';
import ProjectManagement from './ProjectManagement';

import './Admin.scss';

export default function AdminContent() {
    const { setAdmin, isAdmin } = useAdmin();
    const routeMap = new Map([
        ['admin', <AdminDashboard />],
        ['admin/projects', <ProjectManagement />],
        ['admin/management', <Management />],
    ]).map((value, key) => [`/${key}`, value]);

    return (
        <div className='admin-page'>
            {!isAdmin ? <Login /> :
                <>
                    <Navbar routes={routeMap} includeLogo={false} className='admin-nav'>
                        <Button importance='tertiary' crud="delete" iconName='sign-out' onClick={() => setAdmin(null)} value='Logout' />
                    </Navbar>
                    <Routes>
                        {routeMap.array().map(([path, element]) => <Route key={path} path={path.substring('/admin'.length)} element={element} />)}
                        <Route path='*' element={<AdminDashboard />} />
                    </Routes>
                </>
            }
        </div>
    )
}
