import React from 'react';

/**
 * @param {{ value?: string, children?: any[], submit: () => void}} props
 */
export default function LoginButton({ value, children, submit, ...rest }) {
  return (
    <button className="login-button" onClick={() => submit()} {...rest}>
        {value || children}
    </button>
  );
}