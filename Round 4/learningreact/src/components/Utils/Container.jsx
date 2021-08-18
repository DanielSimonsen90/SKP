import React, { Component, createElement } from 'react'

export default class ContainerComponent extends Component {
    constructor(props, ...classNames) {
        super(props);
        
        this.classNames = ['container',
            ...classNames.filter(className => typeof className == 'string'), 
            props.className != undefined && props.className
        ].filter(v => v).join(' ');
    }

    render() {
        return createElement('div', {
            ...this.props,
            className: this.classNames
        })
    }
}
export class ContainerFlexComponent extends ContainerComponent {
    constructor(props, ...classNames) {
        super(props, 'container-flex', ...classNames)
    }
}
export class ContainerPopoutComponent extends ContainerComponent {
    constructor(props, ...classNames) {
        super(props, 'container-popout', ...classNames)
    }
}

export function Container(props) {
    return new ContainerComponent(props).render();
}
export function ContainerFlex(props) {
    return new ContainerFlexComponent(props).render();
}
export function ContainerPopout(props) {
    return new ContainerPopoutComponent(props).render();
}