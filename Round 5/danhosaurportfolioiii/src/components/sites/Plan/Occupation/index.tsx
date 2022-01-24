import { useTranslate } from 'providers/LanguageProvider';
import { useLocationCollection, useMe } from 'providers/MeProvider';
import LinkItem from 'components/shared/navigation/LinkItem';
import './Occupation.scss';

type Props = {
    link?: boolean
}

export default function Occupation({ link = true }: Props) {
    const me = useMe();
    const translate = useTranslate();
    const locationCollection = useLocationCollection();

    const occupationString = translate('occupationString')
        .replace('$module', me.occupation)
        .replace('$date', locationCollection.find(i => i.course === me.occupation).end.toString())

    return <LinkItem id='occupation-string' title={occupationString} 
        link={(link && translate('plan')) || undefined} 
        hoverable={link}
    />
}
