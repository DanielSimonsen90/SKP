import React, { createContext, useState, useEffect, useContext } from 'react'

const LoginContext = createContext();
const LoginAddContext = createContext();
const LoginRemoveContext = createContext();

export function useLogins() {
    return useContext(LoginContext);
}
export function useLoginsAdd() {
    return useContext(LoginAddContext);
}
export function useLoginsRemove() {
    return useContext(LoginRemoveContext);
}

export default function LoginProvider({ children }) {
    const [logins, setLogins] = useState((localStorage.getItem('logins') && JSON.parse(localStorage.getItem('logins'))) || [])
    useEffect(() => {
        localStorage.setItem('logins', JSON.stringify(logins));
    }, [logins])

    function addLogin(login) {
        setLogins(preLogins => [...preLogins, login]);
    }
    function removeLogin(login) {
        setLogins(preLogins => preLogins.filter(l => l != login));
    }

    return (
        <LoginContext.Provider value={logins}>
        <LoginAddContext.Provider value={addLogin}>
        <LoginRemoveContext.Provider value={removeLogin}>
            {children}
        </LoginRemoveContext.Provider>
        </LoginAddContext.Provider>
        </LoginContext.Provider>
    )
}
