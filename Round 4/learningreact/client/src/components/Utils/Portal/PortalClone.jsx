import React from 'react'

/**@param {{ query: string }} props*/
export default function PortalClone({ query, ...rest }) {
    const host = document.querySelector(query);
    const rect = host.getClientRects()[0];
    const rectStyles = "top, bottom, left, right, x, y, height, width"
        .split(', ')
        .reduce((result, prop) => {
            result[prop] = `${Math.round(rect[prop]).toString()}px`;
            return result;
        }, {});
    return (
        <div style={rectStyles} type="clone" {...rest} />
    )
}
