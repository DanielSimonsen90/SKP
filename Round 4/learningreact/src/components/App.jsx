import React from 'react';
import 'styles/utils/index.scss';
import 'styles/App.scss';

import UserProvider from 'providers/UserProvider';
import AppNameProvider from 'providers/AppNameProvider';

import Home from './Home';

export default function App() {
  return (
    <>
    <div id="portals"></div>
      <div id="app">
        <AppNameProvider>
        <UserProvider>
          <Home />
        </UserProvider>
        </AppNameProvider>
      </div>
    </>
  );
}
