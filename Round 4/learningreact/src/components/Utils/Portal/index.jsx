import { cloneElement, useEffect } from 'react';
import { createPortal, } from 'react-dom';
import PortalClone from './PortalClone';

/**
 * @param {{ 
 *  type: 'popout' | 'tooltip' | 'modal', 
 *  cloneQuery: string
 * }} props 
 */
export default function Portal({ type, children, cloneQuery: query, ...rest }) {
    const portal = document.createElement('div');
    portal.setAttribute('type', type);
    const portals = document.getElementById('portals');
    portals.replaceChildren()
    portals.appendChild(portal);

    useEffect(() => {
        portals.style.zIndex = 100;
        return () => portals.removeAttribute('style')
    }, [portals, portals.children])

    useEffect(() => () => portals.replaceChildren(), [portals]);

    const restEvents = Object.keys(rest).reduce((events, prop) => {
        if (prop.startsWith('on')) events[prop] = rest[prop];
        return events;
    }, {})

    return createPortal((
        <>
            <PortalClone query={query} {...restEvents}/>
            {children.map?.(child => cloneElement(child, { ...child.props, ...rest})) || 
            cloneElement(children, { ...children.props, ...rest})}
        </>
    ), portal);
}