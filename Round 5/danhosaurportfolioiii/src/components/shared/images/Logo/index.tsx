import { useRedirect } from 'providers/RouteProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import { ImageContainer } from 'components/shared/container/SpecificContainer';
import './Logo.scss';

export default function Logo() {
    const redirect = useRedirect();

    return (
        <ImageContainer className='logo-container'>
            <LinkItem className='logo' icon='/logo.png' onClick={() => redirect('')} listElement={false} alt="Daniel Simonsen" />
        </ImageContainer>
    )
}
