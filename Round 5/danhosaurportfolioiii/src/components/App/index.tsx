import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { useRoutes } from 'react-router';

import Navbar from '../shared/navigation/Navbar'
import Providers from 'providers'
import Home from '../sites/Home'
import AboutMe from '../sites/AboutMe'
import Projects from '../sites/Projects'
import Plan from '../sites/Plan'
import Admin from '../sites/Admin'
import Footer from 'components/shared/navigation/Footer'

import './App.scss';
import '../shared/scss/PageContent.scss';
import '../shared/scss/Scrollbar.scss';

export const createRoute = (path: string, element: JSX.Element) => ({ path, element });
export type RouteProps = {
    routes: Map<string, JSX.Element>
}

export default function App() {
    const routeMap = new Map(new Map([
        ['', <Home />],
        ['aboutme', <AboutMe />],
        ['projects', <Projects />],
        ['plan', <Plan />],
    ]).entries()).map((value, key) => [`/${key}`, value]);

    return (
        <Providers>
            <Navbar routes={routeMap} />
            <main className="container page-content">
                <Routes>
                    {routeMap.array().map(([path, element]) => <Route key={path} path={path} element={element} />)}
                    <Route path="/admin/*" element={<Admin />} />
                </Routes>
            </main>
            <Footer routes={routeMap} />
        </Providers>
    )
}