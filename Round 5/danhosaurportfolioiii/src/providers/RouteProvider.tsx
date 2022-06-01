import { createContext, useContext, useEffect, useState } from 'react'
import { BaseProps, UseStateReturn, useRedirect as _useRedirect } from 'danholibraryrjs'
import { useTranslate } from './LanguageProvider';

const RouteContext = createContext<UseStateReturn<string>>(["", () => {}]);

export function useRoute() {
    return useContext(RouteContext);
}
export function useRedirect() {
    return useRoute()[1];
}

export default function RouteProvider({ children }: BaseProps) {
    const [route, setRoute] = useState(window.location.pathname);
    const translate = useTranslate();
    const _redirect = _useRedirect();
    const redirect = (to: string | ((from: string) => string)) => setRoute(_redirect(to));

    useEffect(() => {
        const metaTitle = document.querySelector('meta[property="og:title"]');
        const title = document.querySelector('title');
        if (!metaTitle) return;

        const routeName = route.split('/').pop() || 'home';
        const content = `${translate(routeName)} - DanhosaurPortfolio`;
        metaTitle.setAttribute('content', content);
        title.textContent = content;
    }, [route])

    return (
        <RouteContext.Provider value={[route, redirect]}>
            {children}
        </RouteContext.Provider>
    )
}
