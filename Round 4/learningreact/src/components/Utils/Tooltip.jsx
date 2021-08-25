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
    const [style, setStyle] = useState({
        backgroundColor: 'var(--background-color-primary-darker)'
    });
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
        setStyle(preStyle => ({ ...preStyle, ...(() => {
            return {
                top: `${bottom - height / 2 - tooltipSize.height / 2}px`,
                left: `${right - width / 2 - tooltipSize.width / 2}px`,
                ...(() => {
                    switch (dock) {
                        default: case 'top': return {
                            top: `calc(${top - tooltipSize.height}px - 2vh)`,
                            boxShadow: `0vw -.5vh .5vh #111`
                        }
                        case 'bottom': return {
                            top: `calc(${bottom}px + 2vh)`,
                            boxShadow: `0vw .5vh .5vh #111`
                        };
                        case 'right': return {
                            left: `calc(${left + tooltipSize.width}px + 2vw)`,
                            boxShadow: `.25vw 0px .5vh #111`
                        };
                        case 'left': return {
                            left: `calc(${right - left}px - 2vw)`,
                            boxShadow: `-.25vw 0px .5vh #111`
                        };
                    }
                })()
            }

        })() }))
            
        tooltipFor.onmouseenter = () => setShowing(true);
        tooltipFor.onmouseleave = () => setShowing(false);
    }, [dock, query, selfRef, tooltip, tooltipSize.height, tooltipSize.width])


    if (!showing) return null;

    return (
        <div className="tooltip" value={tooltip} style={style} {...rest} ref={selfRef}>
            <Container style={{ backgroundColor: 'unset', border: 'unset' }}>
                {children || tooltip}
            </Container>
            <polygon  />
        </div>
    )
}
