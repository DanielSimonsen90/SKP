import React from 'react';
import Icon from 'react-fontawesome';
import { BaseProps } from 'danholibraryrjs';
import { useRedirect } from 'providers/RouteProvider';
import './LinkItem.scss'

type SelectEvent<Element extends HTMLElement> = 
    React.MouseEvent<Element, MouseEvent> | 
    React.KeyboardEvent<Element>
;
export type LinkItemElement = HTMLLIElement & HTMLDivElement;
type Props<
    IsListItem extends boolean = true, 
> = Omit<BaseProps<LinkItemElement>, 'onClick'> & {
    title?: string,
    alt?: string,
    link?: string,
    icon?: string,
    /**@default false*/
    newPage?: boolean,
    /**@default true */
    hoverable?: boolean,
    /**@default true */
    listElement?: IsListItem,
    onClick?: (props: Props<IsListItem>, e: SelectEvent<LinkItemElement>) => void
}
export type LinkItemProps = Props;
export default function LinkItem<IsListItem extends boolean = true>(props: Props<IsListItem>) {
    const { className, title, link, onClick, children, alt,
        icon: iconPath, newPage = false, hoverable = true, listElement = true,
        ...rest
    } = props;

    const redirect = useRedirect();

    const icon = iconPath && (
        iconPath.endsWith('.png') ? 
            <img className='icon' src={iconPath} alt={alt || title} /> : 
            <Icon className='icon' name={iconPath} alt={title} />
    )
    const content = (
        !title && !children ? null : 
        link ? 
            <a tabIndex={-1} href={link} target={newPage ? "_blank" : "_self"} rel="noreferrer">{title || children}</a> : 
            <p>{title || children}</p>
    );

    const onLinkItemPressed = <Element extends LinkItemElement>(e: SelectEvent<Element>) => {
        onClick?.(props, e);
        if (link) redirect(link);
    }

    const result = listElement ? (
        <li tabIndex={link ? 0 : -1} className={`link-item${(hoverable && ' link-item-hoverable') || ''}${(className && ` ${className}`) || ''}`} 
            onClick={e => onClick?.(props, e as any)}
            onKeyDown={e => e.key === 'Enter' && onLinkItemPressed(e as any)}
            {...rest}
        >
            {icon}
            {content}
        </li>
    ) : (
        <div tabIndex={link ? 0 : -1} className={`link-item${(hoverable && ' link-item-hoverable') || ''}${(className && ` ${className}`) || ''}`} 
            onClick={e => onClick?.(props, e as any)}
            onKeyDown={e => e.key === 'Enter' && onLinkItemPressed(e as any)}
            {...rest}
        >
            {icon}
            {content}
        </div>
    )

    return result;
}