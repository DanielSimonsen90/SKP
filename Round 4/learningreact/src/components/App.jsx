import React, { Component } from 'react';
import Login from './Login';

import 'styles/App.scss';

export default class App extends Component {
  render() {
    return (
      <div id="app">
          <Login />
      </div>
    );
  }
}
