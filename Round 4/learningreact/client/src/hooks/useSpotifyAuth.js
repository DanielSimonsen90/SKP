import React, { useState, useEffect } from 'react';
import axios from 'axios';
import useRedirect from 'hooks/useRedirect';

const redirectUrl = '/Spotify'

export default function useSpotifyAuth(code) {
    const redirect = useRedirect();
    const [accessToken, setAccessToken] = useState('');
    const [refreshToken, setRefreshToken] = useState('');
    const [expiresIn, setExpiresIn] = useState(0);

    useEffect(() => { 
        axios.post('http://localhost:3001/login', { code })
            .then(res => {
                setAccessToken(res.data.accessToken);
                setRefreshToken(res.data.refreshToken);
                setExpiresIn(res.data.expiresIn);
                window.history.pushState({}, null, redirectUrl);
            }).catch(err => { console.error(err); })
    }, [code])

    useEffect(() => {
        if (!refreshToken || !expiresIn) return;
        const interval = setInterval(() => {
            axios.post('http://localhost:3001/refresh', { refreshToken })
                .then(res => {
                    setAccessToken(res.data.accessToken);
                    setExpiresIn(res.data.expiresIn);
                })
                .catch(() => redirect(redirectUrl));
        }, (expiresIn - 60) * 1000);

        return () => clearInterval(interval);
    }, [refreshToken, expiresIn, redirect])

    return accessToken;
}
