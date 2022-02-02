import { BaseProps, Container } from 'danholibraryrjs';
import { useTranslate } from 'providers/LanguageProvider';
import { useRoute } from 'providers/RouteProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import Logo from 'components/shared/images/Logo';
import { RouteProps } from 'components/App';
import './Navbar.scss'

type Props = BaseProps & RouteProps & {
    includeLogo?: boolean,
    fromFooter?: boolean
}

export default function Navbar({ routes, children, className, includeLogo = true, fromFooter = false, ...props }: Props) {
    const translate = useTranslate();
    const [route, redirect] = useRoute();
    
    const navbarRoutes = routes.map(([path]) => path.substring(1)).reverse().map(path => (
        <LinkItem key={path} className={route.toLowerCase() === `/${path.toLowerCase()}` ? 'current-page' : ''} 
            title={translate(path) || translate('home')} link={path.replaceAll(' ', '').toLowerCase()}
        />
    ));

    const content = (<>
        {includeLogo && <Logo />}
        {navbarRoutes}
        {children}
    </>)

    return fromFooter ? (
        <ul className='navbar'>{content}</ul>
    ) : (
        <Container>
            <header className={`navbar${className ? ` ${className}` : ''}`} {...props}>
                {content}
            </header>
        </Container>
    )
}
