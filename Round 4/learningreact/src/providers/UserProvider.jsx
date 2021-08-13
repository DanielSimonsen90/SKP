import React, { createContext, useState, useEffect, useContext } from 'react'

const UserContext = createContext()
const UserUpdateContext = createContext()

export function useUser() {
  return useContext(UserContext);
}
export function useUserUpdate(){
  return useContext(UserUpdateContext);
}

export default function UserProvider({ children }) {
  const [user, setUser] = useState((localStorage.getItem('user') && JSON.parse(localStorage.getItem('user'))) || null);

  useEffect(() => {
    // (function componentWillMount() {
    
    // })();
    return function componentWillUnmount() {
      if (user) localStorage.setItem('user', JSON.stringify(user));
    }
    
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
    <UserContext.Provider value={user}>
      <UserUpdateContext.Provider value={setUser}>
        {children}
      </UserUpdateContext.Provider>
    </UserContext.Provider>
  )
}
