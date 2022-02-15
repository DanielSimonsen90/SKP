import React from 'react';
import Icon from 'react-fontawesome';
import { BaseProps } from 'danholibraryrjs';
import { useRedirect } from 'providers/RouteProvider';
import './LinkItem.scss'

type SelectEvent = React.MouseEvent<HTMLLIElement, MouseEvent> | React.KeyboardEvent<HTMLLIElement>;

type Props = Omit<BaseProps<HTMLLIElement>, 'onClick'> & {
    title?: string,
    link?: string,
    icon?: string,
    /**@default false*/
    newPage?: boolean,
    /**@default true */
    hoverable?: boolean,
    onClick?: (props: Props, e: SelectEvent) => void
}

export default function LinkItem(props: Props) {
    const { className, title, link, onClick, children,
        icon: iconPath, newPage = false, hoverable = true,
        ...rest
    } = props;

    const redirect = useRedirect();

    const icon = iconPath && (iconPath.endsWith('.png') ? 
        <img className='icon' src={iconPath} alt={title} /> : 
        <Icon className='icon' name={iconPath} alt={title} />)
    const content = (
        !title && !children ? null : 
        link ? 
            <a tabIndex={-1} href={link} target={newPage ? "_blank" : "_self"} rel="noreferrer">{title || children}</a> : 
            <p>{title || children}</p>
    );

    const onLinkItemPressed = (e: SelectEvent) => {
        onClick?.(props, e);
        if (link) redirect(link);
    }

    return (
        <li tabIndex={0} className={`link-item${(hoverable && ' link-item-hoverable') || ''}${(className && ` ${className}`) || ''}`} 
            onClick={e => onClick?.(props, e)}
            onKeyDown={e => e.key === 'Enter' && onLinkItemPressed(e)}
            {...rest}
        >
            {icon}
            {content}
        </li>
    )
}
