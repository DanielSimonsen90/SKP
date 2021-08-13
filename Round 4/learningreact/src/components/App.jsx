import 'styles/App.scss';
import React, { useContext } from 'react';

import Login from './Login';
import Dashboard from './Dashboard';
import UserProvider, { useUser } from 'providers/UserProvider';

export default function App() {
  const appName = 'Danho Reacts';
  const user = useUser();
  
  return (
    <div id="app">
      <UserProvider>
        {user ? <Dashboard /> : <Login appName={appName} />}
      </UserProvider>
    </div>
  );
}
