import React, { useState, useEffect } from 'react';
import Spotify from 'spotify-web-api-node';
import axios from 'axios';
import env from 'dotenv';

import useSpotifyAuth from 'hooks/useSpotifyAuth'

import { Container, ContainerFlex } from 'components/Utils/Container';
import Sidebar from 'components/Utils/Sidebar';
import Track from './Track';
import Player from './AudioPlayer';

env.config();

const spotify = new Spotify({ clientId: `b7aac96d228d4b95b660a60e73210f3d` });
export default function SpotifyDashboard({ code }) {
    const accessToken = useSpotifyAuth(code);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [playingTrack, setPlayingTrack] = useState(null);
    const [lyrics, setLyrics] = useState('');

    function onPlay(track) {
        setPlayingTrack(track);
        setSearch('');
        setLyrics('');
    }

    useEffect(() => {
        if (!accessToken) return;
        
        spotify.setAccessToken(accessToken);
    }, [accessToken])

    useEffect(() => {
        if (!search) return setSearchResults([]);
        if (!accessToken) return;
        let cancel = false;

        spotify.searchTracks(search).then(({ body }) => {
            if (cancel) return;

            const tracks = body.tracks.items.map(({ artists, name, url, album }) => ({
                artists, title: name, url, album,
                image: album.images
                    .reduce((smallest, image) => 
                        image.height < smallest.height ? image : smallest, 
                    album.images[0]).url
            }));
            setSearchResults(tracks);
        })

        return () => cancel = true;
    }, [search, accessToken])

    useEffect(() => {
        if (!playingTrack) return;

        axios.get('http://localhost:3001/lyrics', { 
            params: {
                track: playingTrack.title, 
                artist: playingTrack.artists[0].name 
            }
        }).then(({ data }) => {
            setLyrics(data.lyrics)
        })
    }, [playingTrack])

    return (
        <>
            <Sidebar items={[]} />
            <ContainerFlex style={{ backgroundColor: 'unset', boxShadow: 'unset' }}>
                <Container style={{ overflowY: 'hidden', height: '12%' }}>
                    <input type="text" style={{ width: '50%', fontSize: '2em' }}
                        onChange={e => setSearch(e.target.value)} 
                        value={search} 
                    />
                </Container>
                <ContainerFlex id="spotify-content">
                    {searchResults.map(track => <Track value={track} key={track.url} play={onPlay}/>)}
                    {!searchResults.length && <Container>{lyrics}</Container>}
                </ContainerFlex>
                <Player accessToken={accessToken} track={playingTrack} style={{ height: '15%' }}/>
            </ContainerFlex>
        </>
    )
}
