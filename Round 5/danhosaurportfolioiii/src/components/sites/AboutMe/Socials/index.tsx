import { CopyToClipboard } from 'danholibraryjs';
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import LinkItem from 'components/shared/navigation/LinkItem';
import Occupation from 'components/sites/Plan/Occupation';
import './Socials.scss';

export default function Socials() {
    const me = useMe();
    const translate = useTranslate();
    
    const socials = new Array<[string, string]>(
        ['email', me.contact.email],
        ['phone', me.contact.phone],
        ['github', me.contact.github],
        ['linkedin', me.contact.linkedin]
    )

    return (
        <InfoContainer title="socialsTitle" type='flex'>
            <ul>
                {socials.map(([key, value]) => (
                    <LinkItem title={translate(key)} key={key}
                        link={
                            key === 'linkedin' ? value :
                            key === 'github' ? `https://github.com/${value}` : 
                            key === 'email' ? `mailto:${value}` : 
                            null
                        }
                        icon={key}
                        newPage={key !== 'phone'}
                        onClick={() => {
                            if (key === 'phone') CopyToClipboard(value, translate('copyPhoneNumber'))
                        }}
                    />
                ))}
            </ul>
            <Occupation />
        </InfoContainer>
    )
}
