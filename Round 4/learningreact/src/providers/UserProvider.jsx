import { User } from 'models';
import React, { createContext, useState, useEffect, useContext } from 'react'

const UserContext = createContext();
const UserUpdateContext = createContext();
const UserLogoutContext = createContext();

/**@returns {User} */
export function useUser() {
  return useContext(UserContext);
}
/**@returns {(current?: User) => User} */
export function useUserUpdate() {
  return useContext(UserUpdateContext);
}
/**@returns {() => void} */
export function useUserLogout() {
  return useContext(UserLogoutContext);
}

export default function UserProvider({ children }) {
  const [user, setUser] = useState(User.client);

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
