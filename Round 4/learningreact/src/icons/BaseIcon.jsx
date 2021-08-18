import React, { Component } from 'react';
import Portal from 'components/Utils/Portal';

export default class BaseIcon extends Component {
    constructor(props) {
        super(props);
        this.setShowChildren = this.setShowChildren.bind(this);

        this.className = ['icon', this.props.className].filter(v => v).join(' ');
        this.state = {
            showChildren: props.showChildren || false
        }
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

        if (!state) {
            return setTimeout(() => {
                if (this.mouseOnChildren) return;
                this.setState({ showChildren: state })
            }, 250);
        }

        return this.setState({ showChildren: state })
    }

    componentDidMount = () => this.mounted = true;
    componentWillUnmount = () => this.mounted = false;

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
                {this.props.children && this.state.showChildren && (
                    <Portal type="popout"
                        onMouseEnter={() => this.setShowChildren('show', true)}
                        onMouseLeave={() => this.setShowChildren('hide', true)}
                    >
                        {this.props.children}
                    </Portal>
                )}
            </>
        )
    }
}
