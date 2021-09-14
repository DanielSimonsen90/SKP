import React, { useEffect, useState, useMemo } from 'react'
import { ContainerInlineBlock } from 'components/Utils/Container'
import { useUser, useUserUpdate } from 'providers/UserProvider'
import axios from 'axios';

export default function UsernameChanger() {
    const user = useUser();
    const updateUser = useUserUpdate();
    const [value, setValue] = useState(`${user.username}`);

    function onChange({ target }) {
        setValue(target.value)
    }

    useEffect(() => {
        const preValue = value;

        setTimeout(() => {
            if (preValue == value) {
                updateUser(() => user);
            }
        }, 500)
    }, [updateUser, user, value])

    return (
        <ContainerInlineBlock style={{
            overflowX: 'hidden'
        }}>
            <input type="text" value={value} onChange={onChange} />
        </ContainerInlineBlock>
    )
}
