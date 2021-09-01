import React from 'react'
import 'styles/Dashboard/Spotify/index.scss';

import { Container } from 'components/Utils/Container';
import LoginButton from 'components/Login/LoginButton';

const scopes = [
    "streaming", 
    "user-read-email", 
    "user-read-private", 
    "user-library-read", 
    "user-library-modify", 
    "user-read-playback-state", 
    "user-modify-playback-state"
].join('%20');
const AuthURL = [
    `https://accounts.spotify.com/authorize?client_id=b7aac96d228d4b95b660a60e73210f3d`,
    `response_type=code`,
    `redirect_uri=http://localhost:3000/Spotify/`,
    `scope=${scopes}`
].join('&');

export default function Login() {
    return (
        <Container style={{
            justifyContent: 'center',
            alignItems: 'center'
        }}>
            <LoginButton id="spotify-login-button" submit={() => window.location.href = AuthURL} value="Login with Spotify"/>
        </Container>
    )
}
