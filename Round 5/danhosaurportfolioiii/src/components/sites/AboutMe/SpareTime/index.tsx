import { useEffect } from 'react'
import { useMediaQuery, TabBar, TabBarItem } from 'danholibraryrjs';

import { useLanguage } from 'providers/LanguageProvider';
import { useMe, useSetSpareTime } from 'providers/MeProvider';

import InfoContainer from 'components/shared/container/InfoContainer';

import SpareTimeItem from './SpareTimeItem';

import './SpareTime.scss';
import './TabBar.scss';

export default function SpareTime() {
    const me = useMe();
    const [language] = useLanguage();
    const setSpareTime = useSetSpareTime();
    const isTiny = useMediaQuery("600");
    
    useEffect(() => {
        setSpareTime();
    }, [language]);

    return (
        <InfoContainer title="spareTimeTitle">
            {isTiny ? (
                <TabBar>
                    {me.spareTime.map(item => (
                        <TabBarItem key={item.name} 
                            title={item.name} 
                            component={<SpareTimeItem item={item} />} 
                        />
                    ))}
                </TabBar>
            ) : me.spareTime.map(item => <SpareTimeItem key={item.name} item={item} />)}
        </InfoContainer>
    )
}
