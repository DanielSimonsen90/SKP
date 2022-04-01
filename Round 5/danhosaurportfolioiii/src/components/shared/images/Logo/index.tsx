import { useRedirect } from 'providers/RouteProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import './Logo.scss';

export default function Logo() {
    const redirect = useRedirect();

    return (
        <div className='image-container logo-container'>
            <LinkItem className='logo' icon='/logo.png' onClick={() => redirect('')} listElement={false} alt="Daniel Simonsen" />
        </div>
    )
}
