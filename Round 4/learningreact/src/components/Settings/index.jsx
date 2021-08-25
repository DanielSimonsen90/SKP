import React, { useState } from 'react'
import { useUser } from 'providers/UserProvider'
import { Container, ContainerFlex } from 'components/Utils/Container';
import ProfileSettings from './ProfileSettings';
import Tooltip from 'components/Utils/Tooltip';
import Router, { Route } from 'components/Utils/Router';
import useRedirect from 'hooks/useRedirect';

export default function Settings() {
    const user = useUser();
    const redirect = useRedirect();
    const routes = new Map([
        ['profile', ProfileSettings],
        ['test', null]
    ]);
    const sidebarOptions = [...routes.keys()].map(settingType => (
        <>
            <Tooltip dock="right" query={`.settings-item[path="${settingType}"]`}>
                <p>Edit your {settingType} here</p>
            </Tooltip>
            <li className="settings-item" key={settingType} path={settingType}
                onClick={() => onSidebarItemClicked(settingType)}
            >
                {settingType.substring(0, 1).toUpperCase() + 
                settingType.substring(1)}
            </li>
        </>
    ))

    function onSidebarItemClicked(path) {
        redirect(`/settings/${path.toLowerCase()}`)
    }

    return (
        <ContainerFlex row="true" style={{
            height: '100%',
            width: '100%',
            overflow: 'hidden'
        }}>
            <ContainerFlex className="sidebar sidebar-settings" style={{height: '100%', maxHeight: 'unset'}}>
                <ul>{sidebarOptions}</ul>
            </ContainerFlex>
            <Container style={{
                position: 'relative'
            }}>
                <Router>
                    {[...routes.entries()].map(([path, component]) => (
                        <Route to={`/settings/${path.toLowerCase()}`}
                            component={component}
                        />
                    ))}
                </Router>
            </Container>
        </ContainerFlex>
    )
}
