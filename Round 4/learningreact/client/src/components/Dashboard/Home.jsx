import React from 'react'
import Sidebar from 'components/Utils/Sidebar';
import { useUser } from 'providers/UserProvider';
import useRedirect from 'hooks/useRedirect';

export default function DashbaordHome() {
    const user = useUser();
    const redirect = useRedirect();

    return (
        <div id="home">
            <Sidebar items={["Spotify"]} onClick={(e, key) => redirect(`/${key}`)} />
            <h2>Welcome back, {user.username}!</h2>
        </div>
    )
}
