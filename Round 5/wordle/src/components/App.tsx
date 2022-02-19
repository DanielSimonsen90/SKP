import React, { useMemo, useState } from 'react';
import { useEffectOnce, useFetch, useStateArray } from 'danholibraryrjs';
import Board from './Board';
import { KeyStates } from './Key';
import Keyboard from './Keyboard';
import 'styles/App.scss'
import { useEffect } from 'react';

export default function App() {
  const { value: keys, push, remove, length } = useStateArray(new Array<string>());
  const [word, setWord] = useState(new Array<string>());
  const maxLength = useMemo(() => Math.round(Math.random() * 8), []);
  const { value, loading, error } = useFetch(`https://random-word-api.herokuapp.com/word?number=${maxLength}`)

  const allKeys = useMemo(() => ["QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM"]
    .map(row => row.split(''))
    .flat()
    .reduce((result, key) => result.set(key, 'DEFAULT'), new Map<string, KeyStates>()), []
  );
  
  function onSubmit() {

  }
  useEffectOnce(() => {
    document.addEventListener('keydown', e => {
      if (e.key === 'Enter' || e.key === 'NumpadEnter') onSubmit();
      else if (e.key === 'Backspace' || e.key === 'Delete') remove(length - 1);
    });
  })
  useEffect(() => {
    console.log(value);
  }, [value])

  if (loading) {
    return <h1>Loading dictionary...</h1>
  }
  else if (error) {
    console.error(error);
    return (
      <div className="error">
        <h1>Error!</h1>
        <h2>{error.name}</h2>
        <p>{error.message}</p>
        {error.stack && <p>{error.stack}</p>}
      </div>
    )
  }

  return (
    <div className="app">
      <Board keys={allKeys.filter((state, key) => keys.includes(key))} />
      <Keyboard keys={allKeys} onKeyPress={push} />
    </div>
  );
}
