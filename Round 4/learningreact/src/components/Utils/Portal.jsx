import React, { Component } from 'react';
import ReactDOM from 'react-dom';

export default class Portal extends Component {
    constructor(props) {
        super(props);

        this.el = document.createElement('div');
        this.el.setAttribute('portal-type', this.props.type);
        this.portal = document.getElementById('portals');
    }

    setZIndex(index) {
        this.portal.style.zIndex = index;
    }
    componentDidMount = () => {
        this.portal.appendChild(this.el);
        this.setZIndex(100);
    }
    componentWillUnmount = () => {
        this.portal.removeChild(this.el);
        this.setZIndex(0);
    }

    render() {
        return ReactDOM.createPortal(this.props.children, this.el);
    }
}
