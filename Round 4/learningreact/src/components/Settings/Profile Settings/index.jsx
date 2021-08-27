import React from 'react'
import Container from 'components/Utils/Container';
import Images from 'models/Util/Images';
import { useUser } from 'providers/UserProvider';
import Tooltip from 'components/Utils/Tooltip';
import 'styles/Profile/Avatar.scss'
import AvatarChanger from './AvatarChanger';
import UsernameChanger from './UsernameChanger';

export default function ProfileSettings() {
    const user = useUser();



    return (
        <div id="profile-settings">
            <AvatarChanger />
            <UsernameChanger />
        </div>
    )
}
