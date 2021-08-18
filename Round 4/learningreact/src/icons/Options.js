import { createElement } from 'react'
import BaseIcon from './BaseIcon';

export default function OptionsSVG(props) {
    const { fill } = props;
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

    return createElement(BaseIcon, {
        ...defaultProps,
        ...props,
        className: props.className ? 
            `${defaultProps.className} ${props.className}` : 
            defaultProps.className
    });
}