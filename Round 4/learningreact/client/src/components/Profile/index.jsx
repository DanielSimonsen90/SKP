import React from 'react'
import { useUser } from 'providers/UserProvider'

export default function Profile(props) {
    const user = useUser();
    
    return (
        <div>
            Welcome to your profile, {user.username}!
        </div>
    )
}
