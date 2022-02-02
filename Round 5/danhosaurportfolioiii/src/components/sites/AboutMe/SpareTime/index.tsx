import { useEffect } from 'react'
import { useLanguage } from 'providers/LanguageProvider';
import { useMe, useSetSpareTime, dummySpareTime } from 'providers/MeProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import SpareTimeItem from './SpareTimeItem';
import './SpareTime.scss';

export default function SpareTime() {
    const me = useMe();
    const [language] = useLanguage();
    const setSpareTime = useSetSpareTime();
    
    useEffect(() => {
        if (me.spareTime[0].description === dummySpareTime[0].description) {
            setSpareTime();
        }
    }, [language]);

    return (
        <InfoContainer title="spareTimeTitle">
            {me.spareTime.map(item => <SpareTimeItem key={item.name} item={item} />)}
        </InfoContainer>
    )
}
