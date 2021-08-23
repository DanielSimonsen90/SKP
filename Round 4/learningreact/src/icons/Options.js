import React from 'react'
import BaseIcon from './BaseIcon';

export default function OptionsSVG({ fill, className, ...rest }) {
    const r = "16";
    const cx = "64"
    const canvasSize = 128;
    const cy = canvasSize / 8;

    const defaultProps = {
        className: 'icon-options',
        svgChildren: (
            <>
                <circle r={r} cx={cx} cy={cy} fill={fill} />
                <circle r={r} cx={cx} cy={cy * 4} fill={fill} />
                <circle r={r} cx={cx} cy={cy * 7} fill={fill} />
            </>
        )
    }

    const _className = className ? 
        `${defaultProps.className} ${className}` : 
        defaultProps.className;
    const iconProps = {...defaultProps, ...rest};

    return <BaseIcon className={_className} {...iconProps} />
}