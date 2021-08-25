import React, { Component } from 'react';
import Portal from './Portal';

export default class ContainerComponent extends Component {
    constructor(props, ...classNames) {
        super(props);
        
        this.classNames = ['container',
            ...classNames.filter(className => typeof className == 'string'), 
            props.className
        ].filter(v => v).join(' ');
        this.style = this.props.style;
    }

    render() {
        return <div {...this.props} style={this.style} className={this.classNames} />
    }
}
export class ContainerFlexComponent extends ContainerComponent {
    constructor(props, ...classNames) {
        super(props, 'container-flex', ...classNames);

        if (props.row) this.style = {...this.props.style, flexDirection: 'row'}
    }
}
export class ContainerPopoutComponent extends ContainerComponent {
    constructor(props, ...classNames) {
        super(props, 'container-popout', ...classNames);
    }

    render() {
        return (
            <Portal type="popout" {...this.props}>
                <div>
                    <div className={this.classNames}>
                        {this.props.children}
                    </div>  
                </div>
            </Portal>
        )
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