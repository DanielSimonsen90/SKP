import React, { createContext, useContext, useState } from 'react'

const AppName = createContext();

export function useAppName() {
    return useContext(AppName);
}

export default function AppNameProvider({ children }) {
    const [appName] = useState('Danho Reacts');

    return (
        <AppName.Provider value={appName}>
            {children}
        </AppName.Provider>
    )
}
