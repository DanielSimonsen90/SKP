import { Container } from 'danholibraryrjs';
import { RouteProps } from 'components/App';
import { useMe } from 'providers/MeProvider';
import Logo from 'components/shared/images/Logo';
import LanguageSelector from 'components/shared/LanguageSelector';
import Occupation from 'components/sites/Plan/Occupation';
import ThemeToggle from './ThemeToggle';
import Navbar from '../Navbar';
import ToTop from '../ToTop';
import './Footer.scss';

function CopyRight() {
    const currentYear = new Date().getFullYear();
    const me = useMe();

    return <span id="copyright" title={`Copyrighted by ${me.name}, ${currentYear}`}>© {currentYear} • {me.name}</span>
} 

export default function Footer({ routes }: RouteProps) {
    return (
        <footer className='container footer'>
            <Container className="footer-content" style={{ boxShadow: 'unset' }}>
                <header className="footer-top">
                    <Logo />
                    <CopyRight />
                    <Occupation />
                </header>
                <section className="footer-nav">
                    <Navbar routes={routes} includeLogo={false} fromFooter />
                    <ToTop />
                </section>
                <footer className="footer-bottom">
                    <LanguageSelector />
                    <ThemeToggle />
                </footer>
            </Container>
        </footer>
   )
}