import React from 'react';
import 'styles/Login/LoginInput.scss';

export default function LoginInput({ title, type, onInputChange, onKeyPress, value }) {
  const placeholder = `Enter ${title.toLowerCase()} here...`
    
  return (
    <label className="login-input">
      <p>{title}</p> 
      <input 
        type={type}
        value={value}
        placeholder={placeholder}

        onChange={e => onInputChange?.(e.target.value, e)}
        onKeyPress={e => onKeyPress?.(e.key, e)}
      />
    </label>
  );
}
