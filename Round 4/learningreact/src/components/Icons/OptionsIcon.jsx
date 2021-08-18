import OptionsSVG from 'icons/Options';
import React from 'react'
import { ContainerPopout } from 'components/Utils/Container';

export default function OptionsIcon({ containerStyle, style, fill, children, className }) {
    return (
        <OptionsSVG fill={fill} style={style}>
            <ContainerPopout fill={fill} className={className} style={containerStyle}>
                {children}
            </ContainerPopout>
        </OptionsSVG>
    )
}
