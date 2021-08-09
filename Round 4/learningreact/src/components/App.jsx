import React, { Component } from 'react';
import Login from './Login';
import Dashboard from './Dashboard';

import 'styles/App.scss';

export default class App extends Component {
  constructor(props) {
    super(props);

    this.appName = 'Danho Reacts';
    this.state = {
      user: (localStorage.getItem('user') && JSON.parse(localStorage.getItem('user'))) || null
    }

    this.userUpdate.bind(this);
    this.loggedIn.bind(this);
  }

  userUpdate(user) {
    this.setState({ user })
  }
  loggedIn(user) {
    this.userUpdate(user);
  }

  componentWillUnmount() {
    if (this.state.user) localStorage.setItem('user', JSON.stringify(this.state.user));
  }

  render() {
    const login = <Login loggedIn={this.loggedIn} appName={this.appName} />;
    const dashboard = <Dashboard user={this.state.user} userUpdate={this.userUpdate} />;
    const content = this.state.user ? dashboard : login;

    return (
      <div id="app">
          {content}
      </div>
    );
  }
}
