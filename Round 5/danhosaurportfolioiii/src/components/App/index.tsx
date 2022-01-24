import { Container, createRoute, RouteConstruct, Router } from 'danholibraryrjs'
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

export type RouteProps = {
    routes: Array<RouteConstruct>
}

export default function App() {
    const routes: Array<RouteConstruct> = [
        createRoute('plan', Plan),
        createRoute('projects', Projects),
        createRoute('aboutme', AboutMe),
        createRoute('', Home),
    ]

    return (
        <Providers>
            <Navbar routes={routes} />
            <Container className='page-content'>
                <Router routes={[createRoute('admin', Admin), ...routes]} />
            </Container>
            <Footer routes={routes} />
        </Providers>
    )
}