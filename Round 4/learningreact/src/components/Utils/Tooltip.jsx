import React from 'react';
import Portal from './Portal';

export default function Tooltip({ cloneQuery, children, ...rest }) {
    return (
        <div className="tooltip">
            <Portal type="tooltip" cloneQuery={cloneQuery} {...rest}>
                {children}
            </Portal>
        </div>
    )
}
