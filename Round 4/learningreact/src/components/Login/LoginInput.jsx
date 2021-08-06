import React, { Component, ChangeEvent } from 'react';

export default class LoginInput extends Component {
  constructor(props) {
    super(props);

    this.state = {
      value: this.props.value || '',
      inputFor: this.props.inputFor || this.props.title.toLowerCase()
    };

    this.onInputChange = this.onInputChange.bind(this);
  }

  /**@param {ChangeEvent} e*/
  onInputChange(e) {
    // this.setState({ value: e.target.value }, () => {
    //   this.props.onInputChange?.(this, this.state.value, e);
    // })
    this.props.onInputChange?.(this, e.target.value, e)
  }

  render() {
    return (
        <label className="login-input">
            {this.props.title}
            <input 
              type={this.props.type}
              value={this.props.value}
              
              onChange={this.onInputChange}
            />
        </label>
    );
  }
}
