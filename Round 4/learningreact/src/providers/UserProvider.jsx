import React, { createContext, useState, useEffect, useContext } from 'react'

const UserContext = createContext();
const UserUpdateContext = createContext();
const UserLogoutContext = createContext();

export function useUser() {
  return useContext(UserContext);
}
export function useUserUpdate() {
  return useContext(UserUpdateContext);
}
export function useUserLogout() {
  return useContext(UserLogoutContext);
}

export default function UserProvider({ children }) {
  const localUser = localStorage.getItem('user');
  const [user, setUser] = useState((localUser && JSON.parse(localUser)) || null);

  useEffect(() => {
    if (user) 
      localStorage.setItem('user', JSON.stringify(user));
  }, [user]);

  return (
    <UserContext.Provider value={user}>
    <UserUpdateContext.Provider value={setUser}>
    <UserLogoutContext.Provider value={() => setUser(null)}>
      {children}
    </UserLogoutContext.Provider>
    </UserUpdateContext.Provider>
    </UserContext.Provider>
  )
}
