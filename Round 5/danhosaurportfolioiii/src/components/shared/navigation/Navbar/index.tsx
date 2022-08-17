import { useMemo } from 'react';
import Icon from 'react-fontawesome';
import { BaseProps, useMediaQuery, classNames } from 'danholibraryrjs';

import { useTranslate } from 'providers/LanguageProvider';
import { useRoute } from 'providers/RouteProvider';
import { useModal } from 'providers/ModalProvider';

import { RouteProps } from 'components/App';
import LinkItem from 'components/shared/navigation/LinkItem';
import Logo from 'components/shared/images/Logo';

import './Navbar.scss';

type Props = BaseProps & RouteProps & {
    /**@default true */
    includeLogo?: boolean,
    /**@default false */
    fromFooter?: boolean
}

const ensureSlash = (str: string) => str.startsWith('/') ? str : `/${str}`;

export default function Navbar({ routes, children, className, includeLogo = true, fromFooter = false, ...props }: Props) {
    const translate = useTranslate();
    const [route] = useRoute();
    const forceIcon = useMediaQuery("400");
    const navbarRoutes = useMemo(() => routes.map((c, path) => [path.substring(1), c]).array().map(([path]) => {
        const isCurrentPage = route.toLowerCase() === `/${path.toLowerCase()}`;
        const title = translate(path) || translate('home');
        const link = ensureSlash(path.replaceAll(' ', '').toLowerCase() || '/');

        return <LinkItem key={path}
            className={isCurrentPage ? 'current-page' : null}
            title={title} link={!isCurrentPage && link} onClick={() => {
                if (isVisible && isCurrentPage) toggleModal('hide');
            }}
        />
    }), [route, translate, routes]);
    const ContentChildren = () => (<>
        <ul>
            {includeLogo && !forceIcon && <Logo />}
            {navbarRoutes}
        </ul>
        {children}
    </>);

    const [toggleModal, isVisible] = useModal(null, false)

    const Content = () => forceIcon ? <>
        {includeLogo && <Logo />}
        <Icon name='bars' onClick={() => toggleModal('show', (
            <nav className={classNames('navigation-modal', className)}>
                <ContentChildren />
            </nav>)
        )} />
    </> : <ContentChildren />;

    return fromFooter ? (!forceIcon ? (
        <nav className='navbar'>
            <Content />
        </nav>) : null) : (
        <header className={classNames('container', 'navbar', className)} {...props}>
            <Content />
        </header>
    )
}
