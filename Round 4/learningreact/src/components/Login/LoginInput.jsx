import React, { Component, ChangeEvent } from 'react';

export default class LoginInput extends Component {
  constructor(props) {
    super(props);

    this.state = {
      value: ''
    }

    this.onInputChange = this.onInputChange.bind(this);
  }

  /**@param {ChangeEvent} e*/
  onInputChange(e) {
    this.setState({ value: e.target.value })
  }

  render() {
    return (
        <label className="login-input">
            {this.props.title}
            <input type={this.props.type} onChange={this.onInputChange}/>
        </label>
    );
  }
}
