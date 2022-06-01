import { useState } from 'react'
import { useStateWithValidation, useRedirect, Button, useDeepCompareEffect } from 'danholibraryrjs';
import { useAdmin, useFindAdmin } from 'providers/AdminProvider';
import { useModal } from 'providers/ModalProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import './Login.scss';

export default function Login() {
    const [username, setUsername, isValid] = useStateWithValidation(
        v => v && /\w+#\d{4}/g.test(v),
        ""
    )
    const [isLogginIn, setIsLogginIn] = useState(false);
    const { isAdmin, setAdmin } = useAdmin();
    const redirect = useRedirect();
    const [toggleModal] = useModal(null);

    const resetForm = () => {
        setIsLogginIn(false);
        setUsername("");
    }

    const login = async () => {
        setIsLogginIn(true);
        if (isValid) return setAdmin({ username, _id: -1 });

        toggleModal('show', (
            <div className='admin-login-modal'>
                <h1>Invalid username 🤔</h1>
                <p>I don't know who you think you are, "{username}", but you're definitely not an admin!</p>
                <button onClick={() => redirect('')}>sorry</button>
            </div>
        ));
        resetForm();
    }

    useDeepCompareEffect(() => {
        if (isAdmin) redirect(admin => `${admin.substring(1)}/dashboard`);
    }, [isAdmin])

    const form = (<>
        <input type="password" value={username} placeholder="So you're an admin, huh?"
            onChange={e => setUsername(e.target.value)}
            onKeyPress={e => (e.key === 'Enter' || e.key === 'NumpadEnter') && login()}
        />
        <Button type="submit" importance='primary' crud="create" iconName='sign-in' onClick={() => login()} value="Login" />
    </>);
    const loggingIn = <h1>Logging in...</h1>

    return (
        <InfoContainer title='Admin login'>
            {isLogginIn ? loggingIn : form}
        </InfoContainer>
    )
}
