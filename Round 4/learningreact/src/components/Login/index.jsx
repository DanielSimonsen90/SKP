import React, { Component } from 'react'
import LoginConainer from './LoginContainer'

export default class Login extends Component {
    render() {
        return (
            <div id="login-page">
                <h1>Log into {this.props.appName}.</h1>
                <LoginConainer loggedIn={this.props.loggedIn} />
            </div>
        )
    }
}