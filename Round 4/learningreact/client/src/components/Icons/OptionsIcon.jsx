import OptionsSVG from 'icons/Options';
import React from 'react'

export default function OptionsIcon({ containerStyle, style, fill, children, className, cloneQuery }) {
    const containerProps = { fill, className, style: containerStyle, cloneQuery }
    return (
        <OptionsSVG fill={fill} style={style} containerProps={containerProps}>
            {children}
        </OptionsSVG>
    )
}
