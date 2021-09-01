import React, { createContext, useState, useEffect, useContext } from 'react'
import { Login } from '../models'

const LoginContext = createContext();
const LoginAddContext = createContext();
const LoginRemoveContext = createContext();

/**@returns {Login[]} */
export function useLogins() {
    return useContext(LoginContext);
}
/**@returns {(login: Login) => void} */
export function useLoginsAdd() {
    return useContext(LoginAddContext);
}
/**@returns {(login: Login) => void} */
export function useLoginsRemove() {
    return useContext(LoginRemoveContext);
}

export default function LoginProvider({ children }) {
    const [logins, setLogins] = useState(Login.logins)
    useEffect(() => {
        localStorage.setItem('logins', JSON.stringify(logins));
    }, [logins])

    /**@param {Login} login*/
    function addLogin(login) {
        setLogins(preLogins => [...preLogins, login]);
    }
    /**@param {Login} login*/
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
