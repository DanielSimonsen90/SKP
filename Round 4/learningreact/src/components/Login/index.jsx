import React from 'react'
import LoginConainer from './LoginContainer'
import LoginProvider from 'providers/LoginProvider'
import { useUserUpdate } from 'providers/UserProvider'

export default function Login({ appName }) {
    const setUser = useUserUpdate();

    return (
        <div id="login-page">
            <h1>Log into {appName}.</h1>
            <LoginProvider>
                <LoginConainer loggedIn={setUser} />
            </LoginProvider>
        </div>
    )
}