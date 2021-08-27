import React from 'react'
import 'styles/Dashboard/Header.scss';
import getVariable from 'styles/utils';
import useRedirect from 'hooks/useRedirect';

import OptionsIcon from 'components/Icons/OptionsIcon'
import Logo from 'components/Icons/Logo';
import UserSVG from 'icons/User'
import SettingsSVG from 'icons/Settings';

export default function DashboardHeader() {
    const redirect = useRedirect();
    const fill = getVariable('--color-primary');
    const backgroundColor = getVariable('--background-color-primary-darker');
    const containerStyle = { 
        top: '6.5vh',
        right: '0',
        width: '12.5vw',
        height: '15vh'
    }

    return (
        <header id="dashboard-header">
            <Logo />
            <OptionsIcon fill={fill} 
                className="header-options" 
                containerStyle={containerStyle}
                cloneQuery="#dashboard-header > .icon-options"
            >
                <ul>
                    <li onClick={() => redirect('/profile')}>
                        <UserSVG fill={fill} />
                        <p>Profile</p>
                    </li>
                    <li onClick={() => redirect('/settings')}>
                        <SettingsSVG fill={fill} backgroundColor={backgroundColor} />
                        <p>Settings</p>
                    </li>
                </ul>
            </OptionsIcon>
        </header>
    )
}
