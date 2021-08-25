import React, { useState, useEffect, createRef, useCallback } from 'react';
import Container from 'components/Utils/Container';

/**
 * @typedef Dock
 * @type {'top' | 'bottom' | 'left' | 'right'}
 * 
 * @typedef Child
 * @type {JSX.Element | string}
 */


/**
 * @param {{
 *  dock: Dock
 *  query: string,
 *  tooltip: Child,
 *  children: Child[]
 * }} props 
 */
export default function Tooltip({ dock, query, tooltip, children, ...rest }) {
    const [style, setStyle] = useState({});
    const [tooltipSize, setTooltipSize] = useState({ height: 0, width: 0 });
    const [showing, setShowing] = useState(false);
    const selfRef = createRef();
 
    useEffect(() => {
        /**@type {HTMLElement} */
        const tooltipFor = document.querySelector(query);
        const rect = tooltipFor.getClientRects()[0];
        /**@type {{ 
         *  bottom: number, 
         *  top: number, 
         *  left: number, 
         *  right: number, 
         *  width: number, 
         *  height: number 
         * }} */
        const { top, bottom, left, right, width, height } = {
            top: Math.round(rect.top),
            bottom: Math.round(rect.bottom),
            left: Math.round(rect.left),
            right: Math.round(rect.right),
            width: Math.round(rect.width),
            height: Math.round(rect.height),
        };
    
        
        /**@type {{ height: number, width: number }}*/
        const newTooltipSize = {
            height: selfRef.current?.offsetHeight || height,
            width: selfRef.current?.offsetWidth || width
        }

        if (tooltipSize.height && newTooltipSize.width == tooltipSize.width) return;

        setTooltipSize(newTooltipSize);
        setStyle((() => {
            switch (dock) {
                default: case 'top': return {
                    top: `calc(${bottom}px - ${top}px)`,
                    left: `${right - left + width - tooltipSize.width / 2}px`,
                }
                case 'bottom': return {
                    top: `calc(${bottom}px * 4 + ${top}px)`,
                    left: `calc(${right}px * 2 + ${left}px)`,
                };
                case 'left': return {
                    top: `calc(${bottom}px * 2 + ${top}px)`,
                    left: `calc(${right}px - ${left}px)`
                };
                case 'right': return {
                    top: `calc(${bottom}px * 2 + ${top}px)`,
                    left: `calc(${right}px * 4 + ${left}px)`
                };
            }
        })())
            
        tooltipFor.onmouseenter = () => setShowing(true);
        tooltipFor.onmouseleave = () => setShowing(false);
    }, [dock, query, selfRef, tooltip, tooltipSize.height, tooltipSize.width])


    if (!showing) return null;

    return (
        <div className="tooltip" value={tooltip} style={style} {...rest} ref={selfRef}>
            <Container>
                {children || tooltip}
            </Container>
            <polygon  />
        </div>
    )
}
