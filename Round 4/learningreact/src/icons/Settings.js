import React from 'react'
import BaseIcon from './BaseIcon'

export default function SettingsSVG(props) {
    const strokeWidth = 24;
    const one = 8;
    const two = 32; //16
    const three = 48; //16
    const four = 64; //16
    const five = 80; //16
    const six = 96; //16
    const seven = 120; //16

    const data = [
        { type: 'line', x1: one, y1: one, x2: three, y2: three },
        { type: 'line', x1: four, y1: one, x2: four, y2: two },
        { type: 'line', x1: seven, y1: one, x2: five, y2: three },
        { type: 'line', x1: one, y1: four, x2: two, y2: four },
        { type: 'circle', r: two, cx: four, cy: four },
        { type: 'line', x1: six, y1: four, x2: seven, y2: four },
        { type: 'line', x1: one, y1: seven, x2: three, y2: five },
        { type: 'line', x1: four, y1: seven, x2: four, y2: six },
        { type: 'line', x1: seven, y1: seven, x2: five, y2: five },
    ]

    const stroke = props.fill;
    const svgChildren = data.map((item, i) => {
        const { type } = item;

        if (type == 'circle') {
            const { r, cx, cy } = item;
            return (
                <circle r={r} cx={cx} cy={cy} 
                    stroke={stroke} strokeWidth={strokeWidth} key={i}
                />
            )
        }
        else if (type == 'line') {
            const { x1, x2, y1, y2 } = item;
            return (
                <line x1={x1} y1={y1} x2={x2} y2={y2} 
                    stroke={stroke} strokeWidth={strokeWidth} key={i}
                />
            )
        }

        return <></>;
    });

    return <BaseIcon svgChildren={svgChildren} {...props} />
}
