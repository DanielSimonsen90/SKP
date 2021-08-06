import React, { Component } from 'react';

export default class Dashboard extends Component {
    constructor(props) {
      super(props)
    
      this.state = {
         
      };
    };
    
  render() {
    return (
      <div>
          <h1>Hello, {this.props.user}!</h1>
      </div>
    );
  }
}
