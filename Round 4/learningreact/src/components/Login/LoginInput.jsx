import React, { Component, ChangeEvent } from 'react';
import 'styles/Login/LoginInput.scss';

export default class LoginInput extends Component {
  constructor(props) {
    super(props);

    this.placeholder = `Enter ${this.props.title.toLowerCase()} here.`
    this.state = {
      value: this.props.value || '',
      inputFor: this.props.inputFor || this.props.title.toLowerCase()
    };

    this.onInputChange = this.onInputChange.bind(this);
    this.onKeyPress = this.onKeyPress.bind(this);
  }

  /**@param {ChangeEvent} e*/
  onInputChange(e) {
    this.props.onInputChange?.(this, e.target.value, e)
  }
  onKeyPress(e) {
    this.props.onKeyPress?.(this, e.key, e);
  }

  render() {
    return (
      <label className="login-input">
        <p>{this.props.title}</p> 
        <input 
          type={this.props.type}
          value={this.props.value}
          placeholder={this.placeholder}

          onChange={this.onInputChange}
          onKeyPress={this.onKeyPress}
        />
      </label>
    );
  }
}
