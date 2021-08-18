import React from 'react';
import 'styles/utils/index.scss';
import 'styles/App.scss';

import UserProvider from 'providers/UserProvider';
import AppNameProvider from 'providers/AppNameProvider';

import Home from './Home';

export default function App() {
  return (
    <div id="app">
      <AppNameProvider>
      <UserProvider>
        <div id="portals"></div>
        <Home />
      </UserProvider>
      </AppNameProvider>
    </div>
  );
}
