import { createContext, useContext, useState } from 'react'
import { BaseProps, UseStateReturn } from 'danholibraryrjs'

const RouteContext = createContext<UseStateReturn<string>>(["", () => {}]);

export function useRoute() {
    return useContext(RouteContext);
}
export function useRedirect() {
    return useRoute()[1];
}

export default function RouteProvider({ children }: BaseProps) {
    const [route, setRoute] = useState(window.location.pathname);
    const redirect = (state: string | ((state: string) => string)) => {
        const val = typeof state === 'function' ? state(route) : state;
        setRoute(val);
        
        window.location.href = `${window.location.origin}/${val}`;
    }

    return (
        <RouteContext.Provider value={[route, redirect]}>
            {children}
        </RouteContext.Provider>
    )
}
