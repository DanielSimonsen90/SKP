import { createContext, useContext, useEffect, useState } from 'react'
import { BaseProps, UseStateReturn, useRedirect as _useRedirect } from 'danholibraryrjs'
import { useTranslate } from './LanguageProvider';
import { useLocation, useNavigate } from 'react-router';

const RouteContext = createContext<UseStateReturn<string>>(["", () => { }]);

export function useRoute() {
    return useContext(RouteContext);
}
export function useRedirect() {
    return useRoute()[1];
}

export default function RouteProvider({ children }: BaseProps) {
    const route = useLocation().pathname;
    const translate = useTranslate();
    const redirect = _useRedirect();

    useEffect(() => {
        const metaTitle = document.querySelector('meta[property="og:title"]');
        if (!metaTitle) return;

        const routeName = route.split('/').pop() || 'home';
        const content = `${translate(routeName)} - DanhosaurPortfolio`;
        metaTitle.setAttribute('content', content);
        document.querySelector('title')!.textContent = content;
    }, [route])

    return (
        <RouteContext.Provider value={[route, redirect]}>
            {children}
        </RouteContext.Provider>
    )
}
