import { useRoute } from 'providers/RouteProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import './Logo.scss';

export default function Logo() {
    const [route, redirect] = useRoute();
    const icon = `${route.split('/').map(() => '../').join('')}/logo.png`;

    return (
        <div className='image-container logo-container'>
            <LinkItem icon={icon} onClick={() => redirect('')} className='logo' />
        </div>
    )
}
