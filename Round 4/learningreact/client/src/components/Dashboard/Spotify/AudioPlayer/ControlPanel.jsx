import React, { createRef } from 'react'
import { ContainerFlex } from 'components/Utils/Container'

export default function SpotifyControlPanel(props) {
    const { shuffleToggle } = props;
    const { isPlaying, togglePlay } = props;
    const { nextTrack, previousTrack } = props;
    const { loopType, toggleLoopType } = props;

    /**@type function(): React.RefObject<HTMLButtonElement>*/
    const createReference = createRef

    const shuffleRef = createReference();
    const preRef = createReference();
    const playingRef = createReference();
    const nextRef = createReference();
    const loopRef = createReference();

    return (
        <ContainerFlex row>
            <button className="button-shuffle" ref={shuffleRef} value="🔀"
                onClick={() => {
                    shuffleRef.current.classList.toggle('disabled');
                    shuffleToggle(shuffleRef.current.classList.contains('disabled'))
                }} 
            />
            <button className="button-previous" ref={preRef} value="⏮"
                onClick={previousTrack}
            />
            <button className="button-play" ref={playingRef} value={isPlaying ? '▶' : '⏸'}
                onClick={togglePlay}
            />
            <button className="button-next" ref={nextRef} value="⏭"
                onClick={nextTrack}
            />
            <button className="button-loop" ref={loopRef} value={loopType} 
                onClick={toggleLoopType}
            />
        </ContainerFlex>
    )
}
