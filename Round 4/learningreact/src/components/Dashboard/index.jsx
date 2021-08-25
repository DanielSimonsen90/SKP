import React from 'react'
import 'styles/Dashboard/index.scss';
import { useUser } from 'providers/UserProvider';
import Router, { Route } from 'components/Utils/Router';

import DashboardHeader from './Header';
import Home from './Home';
import Profile from 'components/Profile';
import Settings from 'components/Settings';
import useRedirect from 'hooks/useRedirect';

export default function Dashboard() {
  const user = useUser();
  const redirect = useRedirect();

  if (!user) redirect('/login');
  
  return (
    <div id="dashboard">
      <DashboardHeader />
      <div id="dashboard-content">
        <Router>
          <Route path="/profile" component={Profile} />
          <Route path="/settings" component={Settings} />
          <Route path="/" component={Home} />
        </Router>
      </div>
    </div>
  )
}
