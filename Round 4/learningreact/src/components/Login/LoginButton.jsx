import React, { Component, MouseEvent } from 'react';

export default class LoginButton extends Component {
  constructor(props) {
      super(props);
      this.onClick = this.onClick.bind(this);
  }
  
    /**@param {MouseEvent} e*/
  onClick(e) {
    this.props.submit();
  }
  
  render() {
    return (
      <button className="login-button" onClick={this.onClick}>
          {this.props.value || this.props.children}
      </button>
    );
  }
}
