import React from 'react'
import Container from 'components/Utils/Container';
import Images from 'models/Util/Images';
import { useUser } from 'providers/UserProvider';

export default function ProfileSettings() {
    const user = useUser();

    return (
        <div>
            <Container style={{ 
                maxHeight: '25%',
                maxWidth: '12.5%',
                overflow: 'hidden'
            }}>
                {Images.avatars.get(user.avatar, {
                    className: 'avatar'
                })}
            </Container>
        </div>
    )
}
