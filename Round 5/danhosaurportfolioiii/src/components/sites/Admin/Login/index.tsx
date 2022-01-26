import { useState } from 'react'
import { useStateWithValidation, useRedirect } from 'danholibraryrjs';
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
    const { setAdmin } = useAdmin();
    const findAdmin = useFindAdmin();
    const redirect = useRedirect();
    const [visible, setModalVisibility] = useModal((
        <div className='admin-login-modal'>
            <h1>Invalid username 🤔</h1>
            <p>I don't know who you think you are, "{username}", but you're definitely not an admin!</p>
            <button onClick={() => redirect('')}>sorry</button>
        </div>
    ))

    const resetForm = () => {
        setIsLogginIn(false);
        setUsername("");
    }

    const login = async () => {
        setIsLogginIn(true)
        if (!isValid) {
            setModalVisibility('show');
            resetForm();
        }

        const adminResult = await findAdmin(username);
        setAdmin(adminResult);
        if (adminResult) {
            redirect(admin => `${admin.substring(1)}/dashboard`);
        }
        
        resetForm()
    }

    const form = (<>
        <input type="text" value={username} placeholder="So you're an admin, huh?"
            onChange={e => setUsername(e.target.value)}
            onKeyPress={e => e.key === 'Enter' && login()}
        />
        <button onClick={() => login()}>Login</button>
    </>);
    const loggingIn = <h1>Logging in...</h1>

    return (
        <InfoContainer title='Admin login'>
            {isLogginIn ? loggingIn : form}
        </InfoContainer>
    )
}
