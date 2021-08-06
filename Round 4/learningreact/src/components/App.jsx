import React, { Component } from 'react';
import Login from './Login';
import Dashboard from './Dashboard';

import 'styles/App.scss';

export default class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      user: localStorage.getItem('user') || undefined
    }

    this.loggedIn.bind(this);
    this.userUpdate.bind(this);
  }

  loggedIn(user) {
    this.userUpdate(user);
  }
  userUpdate(user) {
    this.setState({ user })
  }

  componentWillUnmount() {
    if (this.state.user) localStorage.setItem('user', this.state.user);
  }

  render() {
    return (
      <div id="app">
          {!this.state.user ? 
            <Login loggedIn={this.loggedIn} /> : 
            <Dashboard 
              user={this.state.user}
              userUpdate={this.userUpdate}
            />
          }
      </div>
    );
  }
}
