import React from 'react'
import 'styles/Icons/Logo.scss'

import { useAppName } from 'providers/AppNameProvider'
import useRedirect from 'hooks/useRedirect';

export default function Logo() {
    const appName = useAppName();
    const redirect = useRedirect();

    return (
        <h2 id="logo" onClick={() => redirect('/')}>{appName}</h2>
    )
}
