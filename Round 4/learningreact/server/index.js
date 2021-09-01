require('dotenv').config();
const express = require('express');
const Spotify = require('spotify-web-api-node');
const cors = require('cors');
const { json, urlencoded } = require('body-parser');
const lyricsFinder = require('lyrics-finder');
const app = express();

app.use(cors());
app.use(json());
app.use(urlencoded({ extended: true }));

const spotifyOptions = {
    redirectUri: `http://localhost:3000/Spotify/`,
    clientId: process.env.SPOTIFY_CLIENT_ID,
    clientSecret: process.env.SPOTIFY_CLIENT_SECRET
}

app.post('/login', async (req, res) => {
    console.log('Handling post /login');
    const { code } = req.body;

    const spotify = new Spotify(spotifyOptions);

    try {
        const data = await spotify.authorizationCodeGrant(code);
        const { 
            access_token: accessToken, 
            refresh_token: refreshToken, 
            expires_in: expiresIn 
        } = data.body
        res.json({ accessToken, refreshToken, expiresIn })
    } catch (err) {
        console.log(err);
        res.status(404).send(JSON.stringify(err));        
    }
})
app.post('/refresh', async (req, res) => {
    console.log('Handling post /refresh');
    const { refreshToken } = req.body;
    const spotify = new Spotify({ ...spotifyOptions, refreshToken });

    try {
        const { body } = await spotify.refreshAccessToken();
        res.json({ 
            accessToken: body.access_token, 
            expiresIn: body.expires_in 
        })
    } catch (err) {
        console.log(err);
        res.status(404).send(JSON.stringify(err)); 
    }
})

app.get('/lyrics', async (req, res) => {
    console.log('Handling get /lyrics');
    const lyrics = await lyricsFinder(req.query.artist, req.query.track) || 'No lyrics found!';
    res.json({ lyrics });
})

app.listen(3001, () => console.log('Listening'));