import React from 'react'
import Dashboard from './Dashboard';
import Login from './Login';

export default function SpotifyHome() {
    const code = new URLSearchParams(window.location.search).get('code');
    return code ? <Dashboard code={code} /> : <Login />
}
