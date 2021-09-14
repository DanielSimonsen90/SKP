import React from 'react'
import { ContainerInlineBlock } from 'components/Utils/Container'
import Tooltip from 'components/Utils/Tooltip';
import Images from 'models/Util/Images';
import { useUser } from 'providers/UserProvider';

export default function AvatarChanger() {
    const user = useUser();
    
    function onAvatarClicked() {
        alert('Hello!')
    }

    return (
        <ContainerInlineBlock className="container-image">
            {Images.avatars.get(user.avatar, {
                className: 'avatar',
                id: "profile-avatar",
                onClick: onAvatarClicked
            })}
            <Tooltip dock="bottom" query="#profile-avatar">
                Change your avatar
            </Tooltip>
        </ContainerInlineBlock>
    )
}
