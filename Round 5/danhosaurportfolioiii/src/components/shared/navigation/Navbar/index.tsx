import Icon from 'react-fontawesome';
import { BaseProps, Container, useMediaQuery, ensureSlash } from 'danholibraryrjs';

import { useTranslate } from 'providers/LanguageProvider';
import { useRoute } from 'providers/RouteProvider';
import { useModal } from 'providers/ModalProvider';

import { RouteProps } from 'components/App';
import LinkItem from 'components/shared/navigation/LinkItem';
import Logo from 'components/shared/images/Logo';

import './Navbar.scss'

type Props = BaseProps & RouteProps & {
    includeLogo?: boolean,
    fromFooter?: boolean
}

export default function Navbar({ routes, children, className, includeLogo = true, fromFooter = false, ...props }: Props) {
    const translate = useTranslate();
    const [route] = useRoute();
    const forceIcon = useMediaQuery("400");
    
    const navbarRoutes = routes.map(([path]) => path.substring(1)).reverse().map(path => {
        const isCurrentPage = route.toLowerCase() === `/${path.toLowerCase()}`;
        const title = translate(path) || translate('home');
        const link = ensureSlash(path.replaceAll(' ', '').toLowerCase() || '/');
        
        return <LinkItem key={path} 
            className={isCurrentPage ? 'current-page' : ''} 
            title={title} link={!isCurrentPage && link} onClick={(props, e) => {
                if (isVisible && isCurrentPage) toggleModal('hide');
            }}
        />
    });

    const contentChildren = <>
        {navbarRoutes}
        {children}
    </>

    const [toggleModal, isVisible] = useModal((
        <nav className={`navigation-modal${className ? ` ${className}` : ''}`}>
            {contentChildren}
        </nav>
    ), false)

    const content = (<>
        {includeLogo && <Logo />}
        {forceIcon ? <Icon name='bars' onClick={() => toggleModal('show')} /> : contentChildren}
    </>)

    return fromFooter ? (!forceIcon ? <ul className='navbar'>{content}</ul> : null) : (
        <Container>
            <header className={`navbar${className ? ` ${className}` : ''}`} {...props}>
                {content}
            </header>
        </Container>
    )
}
