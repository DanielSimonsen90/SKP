import { useMemo } from "react";
import { ClickEvent, Component, useClickOutside, useEventListener } from "danholibraryrjs";
import { ToggleModal, useModal } from "providers/ModalProvider";

type ContextData<Element extends HTMLElement> = {
    query: string,
    allow: boolean,
    visible: boolean,
    toggle: ToggleModal,
    event: MouseEvent,
    element: Element
}
type ComponentConstruct<Element extends HTMLElement> = Component | ((data: ContextData<Element>) => Component)

export default function useContextMenu<Element extends HTMLElement>(query: string, component: ComponentConstruct<Element>, validation: Array<boolean> = [true]) {
    const [toggle, visible] = useModal(<div>Hello, World!</div>);
    const allow = useMemo(() => validation.every(b => b), [validation]);

    useClickOutside(query, () => visible && toggle('hide'));
    useEventListener<'contextmenu', Element>('contextmenu', (event, element) => {
        if (!allow) return;

        event.preventDefault();
        event.stopImmediatePropagation();

        toggle('show',
            typeof component === 'function' ?
                component({ allow, query, visible, toggle, element, event }) :
                component
        );
    }, query);
}