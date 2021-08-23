import React, { useState, createElement } from 'react';
import LoginInput from './LoginInput';
import LoginButton from './LoginButton';
import Container from 'components/Utils/Container';

import 'styles/Login/index.scss'
import { useLogins } from 'providers/LoginProvider';
import { useLoginsAdd } from 'providers/LoginProvider';

class InputData {
  /**@param {string} title @param {'text' | 'password'} type */
  constructor(title, type) {
    this.title = title;
    this.type = type;
  }
}

export default function Login({ loggedIn }) {
  const [logins, addLogin] = [useLogins(), useLoginsAdd()];
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const loginData = {
    username, password,
    setUsername, setPassword
  };

  const inputData = [
    new InputData('Username', 'text'),
    new InputData('Password', 'password')
  ]

  function onInputChange(data, value, e) {
    loginData[`set${data.title}`](value);
  }

  function onKeyPress(key, e) {
    if (key == 'Enter') onSubmit();
  }

  function onSubmit() {
    if (!username || !password) {
      return alert(`Please provide a ${!username ? 'username' : 'password'}.`);
    }

    const login = {
      ...Object.keys(loginData)
        .filter(prop => typeof loginData[prop] != 'function')
        .reduce((result, prop) => {
          result[prop] = loginData[prop];
          return result;
        }, {})
    };

    console.log(logins);
    if (!logins.length || !logins.find(l => l.username == login.username)) {
      addLogin(login);
    }
    else if (logins.find(l => l.username == login.username && l.password != login.password)) {
      return alert(`Invalid password for user ${username}!`);
    }

    loggedIn(login);
  }

  return (
    createElement(Container, { loggedIn, className: "login-container" }, 
      <>
        {inputData.map((data, i) => {
          const { title, type } = data;

          return (
            <LoginInput key={i}
              title={title} type={type} value={loginData[title.toLowerCase()]}
              onInputChange={(value, e) => onInputChange(data, value, e)} onKeyPress={(key, e) => onKeyPress(key, e)}
            />
          )
        })}
        <LoginButton value="Login" submit={onSubmit}/>
      </>
    )
  );
}