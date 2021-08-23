import React, { Component, cloneElement, createRef } from 'react';
import { ContainerPopout } from 'components/Utils/Container';

export default class BaseIcon extends Component {
    constructor(props) {
        super(props);
        this.setShowChildren = this.setShowChildren.bind(this);

        this.className = ['icon', this.props.className].filter(v => v).join(' ');
        this.state = { showChildren: props.showChildren || false }

        this.children = this.props.children && cloneElement(this.props.children, {
            onMouseEnter: () => this.setShowChildren('show', true),
            onMouseLeave: () => this.setShowChildren('hide', true)
        })

        this.lastAction = createRef();
    }

    mouseOnChildren = false;
    mounted = false;

    /**@param {'toggle' | 'show' | 'hide'} actionType
     * @param {boolean} isChildren*/
    setShowChildren(actionType, isChildren) {
        const state = 
            actionType == 'toggle' ? !this.state.showChildren :
            actionType == 'show' ? true : false;
        if (isChildren) this.mouseOnChildren = state;

        this.lastAction = { 
            actionType, 
            state, 
            isChildren, 
            onChildren: this.mouseOnChildren 
        }
        if (state) return this.setState({ showChildren: state });

        setTimeout(() => {
            if (this.mouseOnChildren || !this.mounted) return;
            this.setState({ showChildren: state })
        }, 250);
    }

    componentDidMount = () => this.mounted = true;
    componentWillMount = () => this.mounted = false;

    componentDidUpdate() {
        console.log(this.lastAction)
    }

    render() {
        return (
            <>
                <svg className={this.className} xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 128 128" fill="none" 
                    onMouseEnter={() => this.setShowChildren('show')}
                    onMouseLeave={() => this.setShowChildren('hide')}
                >
                    {this.props.svgChildren}
                </svg>
                {this.children && this.state.showChildren && (
                    <ContainerPopout {...this.props.containerProps}
                        onMouseEnter={() => this.setShowChildren('show', true)}
                        onMouseLeave={() => this.setShowChildren('hide', true)}
                    >
                        {this.children}
                    </ContainerPopout>
                )}
            </>
        )
    }
}