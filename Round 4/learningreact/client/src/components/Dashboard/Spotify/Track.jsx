import React from 'react';
import { ContainerFlex, Container } from 'components/Utils/Container';

export default function Track({ value, play }) {
    const { title, album, artists, image } = value;
    console.log(value);

    return (
        <ContainerFlex row className="track" onClick={() => play(value)}>
            <img src={image} alt="" />
            <ContainerFlex className="track-info" style={{ backgroundColor: 'unset' }}>
                <h4 title={title}>{title}</h4>
                <p>{artists.map(a => a.name).join(', ')}</p>
                <h6>{album.name}</h6>
            </ContainerFlex>
        </ContainerFlex>
    )
}
