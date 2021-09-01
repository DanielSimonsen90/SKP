import React from 'react'
import { ContainerFlex } from './Container'
import Tooltip from './Tooltip'

/**
 * @param {{ 
 *  items: string[], 
 *  tooltipText: (key: string) => string,
 *  onClick: (e: MouseEvent, key: string) => any
 * }} props 
 */
export default function Sidebar({ items, tooltipText, onClick, ...rest }) {
    return (
        <ContainerFlex className="sidebar" {...rest}>
            <ul>
                {items.map(item => (
                    <div key={item}>
                        {tooltipText && 
                            <Tooltip dock="right" query={`.sidebar-item[path="${item}"]`}>
                                <p>{tooltipText(item)}</p>
                            </Tooltip>
                        }
                        <li className="sidebar-item" path={item}
                            onClick={e => onClick(e, item)}
                        >
                            {item.substring(0, 1).toUpperCase() +
                            item.substring(1)} 
                        </li>
                    </div>
                ))}
            </ul>
        </ContainerFlex>
    )
}
