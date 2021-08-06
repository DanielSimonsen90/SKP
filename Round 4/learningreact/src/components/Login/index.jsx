import React, { Component, createRef } from 'react';
import LoginInput from './LoginInput';
import LoginButton from './LoginButton';

import 'styles/Login/index.scss'

export default class Login extends Component {
  constructor(props) {
    super(props);

    this.username = {...createRef(), get value() {
      return this.current.state.value;
    }}
    this.password = createRef();

    this.onSubmit = this.onSubmit.bind(this);
  }

  onSubmit() {
      console.log(this);
  }

  render() {
    return (
      <div className="login-container">
          <LoginInput ref={this.username} title="Username" type="text" className="test" />
          <LoginInput ref={this.password} title="Password" type="password" />
          <LoginButton value="Click me!" submit={this.onSubmit}/>
      </div>
    );
  }
}