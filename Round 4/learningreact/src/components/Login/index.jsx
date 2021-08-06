import React, { Component } from 'react';
import LoginInput from './LoginInput';
import LoginButton from './LoginButton';

import 'styles/Login/index.scss'

export default class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      username: '',
      password: ''
    }

    this.onSubmit = this.onSubmit.bind(this);
    this.onInputChange = this.onInputChange.bind(this);
  }


  onInputChange(component, value, e) {
    this.setState(new Map([
      ['username', { username: value }],
      ['password', { password: value }]
    ]).get(component.state.inputFor))
  }

  onSubmit() {
    const login = {...this.state, toString() {
      return this.username;
    }};
    const logins = localStorage.getItem('logins') || [];

    if (!logins.length || !logins.includes(login)) {
      logins.push(login);
    }

    localStorage.setItem('logins', logins);

    this.props.loggedIn(login);
  }

  render() {
    return (
      <div className="login-container">
          <LoginInput onInputChange={this.onInputChange} value={this.state.username} title="Username" type="text" className="test" />
          <LoginInput onInputChange={this.onInputChange} value={this.state.password} title="Password" type="password" />
          <LoginButton value="Click me!" submit={this.onSubmit}/>
      </div>
    );
  }
}