import React from 'react';
import { useUser } from 'providers/UserProvider';

import Dashboard from './Dashboard';
import Login from './Login'
import Router, { Redirect, Route} from 'components/Utils/Router';

export default function Home() {
    const user = useUser();

    return (
        <Router>
            <Route path="/login" component={Login} />
            <Route render={() => (
                user && window.location.pathname != '/login' ?
                    <Dashboard /> :
                    <Redirect to={{ pathname: "/login" }} />
            )} />
        </Router>
    )
}
