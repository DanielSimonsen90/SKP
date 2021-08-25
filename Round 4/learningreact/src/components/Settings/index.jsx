import React, { useState } from 'react'
import { useUser } from 'providers/UserProvider'
import { ContainerFlex } from 'components/Utils/Container';
import ProfileSettings from './ProfileSettings';
import Tooltip from 'components/Utils/Tooltip';

export default function Settings() {
    const user = useUser();
    const [currentRoute, setCurrentRoute] = useState('Profile');
    const routes = new Map([
        ['Profile', ProfileSettings],
        ['Test', null]
    ]);
    const sidebarOptions = [...routes.keys()].map(settingType => (
        <li className="settings-item" key={settingType}
            onClick={() => onSidebarItemClicked(settingType)}
        >
            {settingType}
        </li>
    ))

    function onSidebarItemClicked(item) {

    }

    return (
        <div>
            <Tooltip tooltip={"yo what's up guys my name is skinnypp"} query="#test" key="test" />
            <p id="test" style={{ display: 'inline-block', position: 'absolute', left: '23vw' }}>Welcome to your settings, {user.username}!</p>

            <ContainerFlex className="sidebar sidebar-settings">
                <ul>
                    {sidebarOptions}
                </ul>
            </ContainerFlex>
            
        </div>
    )
}
