import React from 'react';
import { BaseProps } from 'danholibraryrjs';
import './LinkItem.scss'

type SelectEvent = React.MouseEvent<HTMLLIElement, MouseEvent> | React.KeyboardEvent<HTMLLIElement>;

type Props = BaseProps<HTMLLIElement> & {
    title?: string,
    link?: string,
    icon?: string,
    newPage?: boolean, //false
    hoverable?: boolean, //true
    onClick?: (props: Props, e: SelectEvent) => void
}

export default function LinkItem(props: Props) {
    const { className, title, link, onClick, children,
        icon: iconPath, newPage = false, hoverable = true ,
        ...rest
    } = props;
    const icon = iconPath && <img className='icon' src={iconPath.endsWith('.png') ? iconPath : iconPath + '.png'} alt={title} />;
    const content = !title && !children ? null : link ? (
        <a href={link} target={newPage ? "_blank" : "_self"} rel="noreferrer">{title || children}</a>
    ) : <p>{title || children}</p>

    return (
        <li tabIndex={0} className={`link-item ${(hoverable && 'link-item-hoverable') || ''} ${className || ''}`} 
            onClick={e => onClick?.(props, e)}
            onKeyPress={e => e.key === 'Enter' && onClick?.(props, e)}
            {...rest}
        >
            {icon}
            {content}
        </li>
    )
}
