import React from 'react'
import BaseIcon from './BaseIcon'

export default function UserSVG({ fill, ...props }) {
    const svgChildren = (
        <>
            <circle r="24" cx="64" cy="48" fill={fill} />
            <circle r="40" cx="64" cy="124" fill={fill} />
        </>
    )

    return <BaseIcon svgChildren={svgChildren} {...props} />
}
