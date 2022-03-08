import { createContext, useContext, useState } from 'react'
import { BaseProps, UseStateReturn, useRedirect as _useRedirect } from 'danholibraryrjs'

const RouteContext = createContext<UseStateReturn<string>>(["", () => {}]);

export function useRoute() {
    return useContext(RouteContext);
}
export function useRedirect() {
    return useRoute()[1];
}

export default function RouteProvider({ children }: BaseProps) {
    const [route, setRoute] = useState(window.location.pathname);
    const _redirect = _useRedirect();
    const redirect = (to: string | ((from: string) => string)) => setRoute(_redirect(to));

    return (
        <RouteContext.Provider value={[route, redirect]}>
            {children}
        </RouteContext.Provider>
    )
}
