import { useRedirect } from 'providers/RouteProvider';
import { ImageContainer } from 'components/shared/container/SpecificContainer';
import './Portrait.scss';

type Props = {
    uwuVerySecret?: boolean
}

export default function Portrait({ uwuVerySecret = false }: Props) {
    const redirect = useRedirect();

    return (
        <ImageContainer className='portrait-container' style={{ boxShadow: 'none' }} >
            <img className='portrait' src="profile_picture.png" alt="Flot fyr ham der" 
                onClick={() => uwuVerySecret && redirect('admin')}
            />
        </ImageContainer>
    )
}
