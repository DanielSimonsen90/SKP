import React from 'react';

export default function LoginButton({ value, children, submit }) {
  return (
    <button className="login-button" onClick={() => submit()}>
        {value || children}
    </button>
  );
}