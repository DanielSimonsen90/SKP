import React, { useState, useCallback } from 'react'
import { useUser, useUserUpdate, useUserLogout } from 'providers/UserProvider'

import LoginConainer from './LoginContainer'
import LoginButton from './LoginButton';
import LoginProvider from 'providers/LoginProvider'
import { useAppName } from 'providers/AppNameProvider';
import useRedirect from 'hooks/useRedirect';

export default function Login() {
    const appName = useAppName();
    const user = useUser();
    const userUpdate = useUserUpdate();
    const userLogout = useUserLogout();
    const redirect = useRedirect();
    
    const [isLoggedIn, setIsLoggedIn] = useState(user != null);
    const logout = useCallback(() => {
        userLogout();
        setIsLoggedIn(false);
    }, [userLogout])

    async function onLogin(user) {
        userUpdate(user);
        redirect('/dashboard');
    }

    return (
        <div id="login-page">
            {isLoggedIn ? (
            <>
                <h2>You're already logged in as {user.username}.</h2>
                <p>Do you want to sign out?</p>
                <button onClick={logout}>Log out</button>
                <LoginButton submit={() => redirect('/dashboard')}>Take me back!!</LoginButton>
            </>
            ) : (
            <>
                <h1>Log into {appName}.</h1>
                <LoginProvider>
                    <LoginConainer loggedIn={onLogin} />
                </LoginProvider>
            </>
            )}
        </div>
    )
}