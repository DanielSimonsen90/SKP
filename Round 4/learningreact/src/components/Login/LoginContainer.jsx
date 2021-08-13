import React, { useState, useEffect } from 'react';
import LoginInput from './LoginInput';
import LoginButton from './LoginButton';

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
  const logins = useLogins();
  const addLogin = useLoginsAdd();

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
    console.log(data);

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
        }, {}), 
      toString() { return this.username; }
    };

    if (!logins.length || !logins.includes(login)) {
      addLogin(login);
    }

    loggedIn(login);
  }

  return (
    <div className="login-container">
      {inputData.map((data, i) => {
        const { title, type } = data;

        return (
          <LoginInput key={i}
            title={title} type={type} value={loginData[title.toLowerCase()]}
            onInputChange={(value, e) => onInputChange(data, value, e)} onKeyPress={(key, e) => onKeyPress(data, key, e)}
          />
        )
      })}
      <LoginButton value="Log in" submit={onSubmit}/>
    </div>
  );
}