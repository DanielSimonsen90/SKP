import React, { useState } from 'react';
import { ContainerFlex } from 'components/Utils/Container';
import ControlPanel from './ControlPanel'
import ProcessBar from './ProcessBar';

const LoopTypes = {
    QUEUE: '🔁',
    TRACK: '🔂'
}

export default function Player({ accessToken, track }) {
    const [isShuffle, setIsShuffle] = useState(false);
    const [isPlaying, setIsPlaying] = useState(false);
    const [loopType, setLoopType] = useState(LoopTypes.QUEUE);

    if (!accessToken || !track || !track.uri) return null;

    return (
        <ContainerFlex>
            <ControlPanel shuffleToggle={value => setIsShuffle(value)}
                isPlaying={isPlaying} togglePlay={() => setIsPlaying(pre => !pre)}
                nextTrack={() => console.log('Next track')} previousTrack={() => console.log('Previous track')}
                loopType={loopType} toggleLoopType={setLoopType(pre => {
                    switch (pre) {
                        case LoopTypes.QUEUE: return LoopTypes.TRACK;
                        case LoopTypes.TRACK: return null;
                        default: return LoopTypes.QUEUE;
                    }
                })}
            />
            <ProcessBar />
        </ContainerFlex>
    )
}
