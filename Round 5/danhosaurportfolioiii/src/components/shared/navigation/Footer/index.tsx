import { Container } from 'danholibraryrjs';
import { RouteProps } from 'components/App';
import { useMe } from 'providers/MeProvider';
import Logo from 'components/shared/images/Logo';
import LanguageSelector from 'components/shared/LanguageSelector';
import Occupation from 'components/sites/Plan/Occupation';
import Navbar from '../Navbar';
import ToTop from '../ToTop';
import './Footer.scss';

export default function Footer({ routes }: RouteProps) {
    const me = useMe();
    const currentYear = new Date().getFullYear();

    return (
        <Container>
            <footer className='navbar footer'>
                <Logo />
                <p title={`Copyrighted by ${me.name}, ${currentYear}`}>© {currentYear} • {me.name}</p>
                <Navbar routes={routes} includeLogo={false} fromFooter={true} />
                <ToTop />
                <Occupation />
                <LanguageSelector />
            </footer>
        </Container>
    )
}


