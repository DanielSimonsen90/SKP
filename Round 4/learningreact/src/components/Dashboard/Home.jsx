import { useUser } from 'providers/UserProvider'
import React from 'react'

export default function DashbaordHome() {
    const user = useUser();

    return (
        <h2>Welcome back, {user.username}!</h2>
    )
}
