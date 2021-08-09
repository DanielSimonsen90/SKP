import React, { Component } from 'react';
import LoginInput from './LoginInput';
import LoginButton from './LoginButton';

import 'styles/Login/index.scss'

class InputData {
  constructor(title, type, value) {
    this.title = title;
    this.type = type;
  }
}


export default class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      username: '',
      password: ''
    }

    this.inputData = [
      new InputData('Username', 'text'),
      new InputData('Password', 'password')
    ];

    this.onInputChange = this.onInputChange.bind(this);
    this.onKeyPress = this.onKeyPress.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }


  onInputChange(component, value, e) {
    this.setState(new Map([
      ['username', { username: value }],
      ['password', { password: value }]
    ]).get(component.state.inputFor))
  }
  onKeyPress(component, key, e) {
    if (key == 'Enter') this.onSubmit();
  }

  onSubmit() {
    console.log(this.state)
    if (!this.state.username || !this.state.password) {
      return alert(`Please provide a ${!this.state.username ? 'username' : 'password'}.`);
    }

    const login = {...this.state, toString() {
      return this.username;
    }};
    const logins = JSON.parse(localStorage.getItem('logins')) || [];

    if (!logins.length || !logins.includes(login)) {
      logins.push(login);
    }

    localStorage.setItem('logins', logins);

    this.props.loggedIn(login);
  }

  render() {
    return (
      <div className="login-container">
        {this.inputData.map(({ title, type }) => 
          <LoginInput
            title={title} type={type} value={this.state[title.toLowerCase()]} key={title}
            onInputChange={this.onInputChange} onKeyPress={this.onKeyPress}
          />
        )}
        <LoginButton value="Log in" submit={this.onSubmit}/>
      </div>
    );
  }
}