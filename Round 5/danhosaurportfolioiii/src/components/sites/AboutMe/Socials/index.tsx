import { CopyToClipboard } from 'danholibraryjs';
import { useTranslate } from 'providers/LanguageProvider';
import { useMe } from 'providers/MeProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import LinkItem from 'components/shared/navigation/LinkItem';
import Occupation from 'components/sites/Plan/Occupation';
import './Socials.scss';

type SocialsItem = {
    value: string,
    icon: string,
    link?: string,
}

export default function Socials() {
    const me = useMe();
    const translate = useTranslate();
    
    const socials = new Array<[string, SocialsItem]>(
        ['email', {
            value: me.contact.email,
            link: `mailto:${me.contact.email}`,
            icon: 'envelope'
        }],
        ['phone', {
            value: me.contact.phone,
            icon: 'phone'
        }],
        ['github', {
            value: me.contact.github,
            link: `https://github.com/${me.contact.github}`,
            icon: 'github'
        }],
        ['linkedin', {
            value: me.contact.linkedin,
            link: `https://www.linkedin.com/in/${me.contact.linkedin}`,
            icon: 'linkedin.png'
        }]
    )

    return (
        <InfoContainer title="socialsTitle" type='flex'>
            <ul>
                {socials.map(([key, { value, icon, link }]) => (
                    <LinkItem title={translate(key)} key={key}
                        link={link} icon={icon} newPage={key !== 'phone'}
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
