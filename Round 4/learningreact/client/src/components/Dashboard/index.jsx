import React from 'react'
import 'styles/Dashboard/index.scss';
import { useUser } from 'providers/UserProvider';
import Router from 'components/Utils/Router';

import DashboardHeader from './Header';
import Home from './Home';
import Profile from 'components/Profile';
import Settings from 'components/Settings';
import useRedirect from 'hooks/useRedirect';
import SpotifyHome from './Spotify';

export default function Dashboard() {
  const user = useUser();
  const redirect = useRedirect();

  if (!user) redirect('/login');
  
  /**@type [string, () => JSX.Element]*/
  const routes = [
    ['profile', Profile],
    ['settings', Settings],
    ['spotify', SpotifyHome],
    ['', Home]
  ].map(([key, value]) => [`/${key}`, value]);

  return (
    <div id="dashboard">
      <DashboardHeader />
      <div id="dashboard-content">
        <Router routes={routes} />
      </div>
    </div>
  )
}
