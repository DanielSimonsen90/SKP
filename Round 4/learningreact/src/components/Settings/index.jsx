import React, { useState } from 'react'
import 'styles/Settings/index.scss';
import { useUser } from 'providers/UserProvider'
import { Container, ContainerFlex } from 'components/Utils/Container';
import ProfileSettings from './Profile Settings/index';
import Tooltip from 'components/Utils/Tooltip';
import Router, { Route } from 'components/Utils/Router';
import useRedirect from 'hooks/useRedirect';
import Sidebar from 'components/Utils/Sidebar';

export default function Settings() {
    const user = useUser();
    const redirect = useRedirect();
    const routes = new Map([
        ['profile', ProfileSettings],
        ['test', null]
    ]);
    const sidebarOptions = [...routes.keys()].map(settingType => (
        <div key={settingType}>
            <Tooltip dock="right" query={`.settings-item[path="${settingType}"]`}>
                <p>Edit your {settingType} here</p>
            </Tooltip>
            <li className="settings-item" path={settingType}
                onClick={() => onSidebarItemClicked(settingType)}
            >
                {settingType.substring(0, 1).toUpperCase() + 
                settingType.substring(1)}
            </li>
        </div>
    ))

    function onSidebarItemClicked(path) {
        redirect(`/settings/${path.toLowerCase()}`)
    }

    return (
        <ContainerFlex className="settings">
            <Sidebar className="sidebar sidebar-settings"
                items={[...routes.keys()]} 
                tooltipText={key => `Edit your ${key} here.`}
                onClick={(e, key) => onSidebarItemClicked(key)}
            />
            <Container className="sidebar-content">
                <Router>
                    {[...routes.entries()].map(([path, component]) => (
                        <Route key={path}
                            to={`/settings/${path.toLowerCase()}`}
                            component={component}
                        />
                    ))}
                </Router>
            </Container>
        </ContainerFlex>
    )
}
