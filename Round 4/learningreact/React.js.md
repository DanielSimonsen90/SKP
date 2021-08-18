# Learning React.js with Danhoesaur

## What is React.js?
React.js is a [component-based](https://reactjs.org/static/eb8bda25806a89ebdc838813bdfa3601/6b2ea/thinking-in-react-components.png) framework, developed and used for [Facebook](https://facebook.com/).
It's a very popular framework among website developers, and you find most popular websites use it, such as [Facebook](https://facebook.com) (duh), [Twitter](https://twitter.com), [Twitch](https://twitch.tv), [Discord](https://discord.com), [Mojang](https://minecraft.net), [Blizzard Entertainment](https://blizzard.com), [Rockstar Games](https://socialclub.rockstargames.com), [Epic Games](https://www.epicgames.com) and even [dr.dk](https://dr.dk) & [e-boks](https://e-boks.com/danmark/da)

I don't know how to explain things, so instead, you should [listen to ma boi Mosh](https://www.youtube.com/watch?v=N3AkSS5hXMA)...

*pst do yourself a favor and install the [Chrome React Developer Tools Extension](https://chrome.google.com/webstore/detail/react-developer-tools/fmkadmapgofadopljbjfkapdkoienihi), so you can see your components in inspection*

## Install

### Must have:
* Node.js to use `npm install <module>`
* npx & create-react-app => `npm i npx create-react-app -g`
You will then have installed Node.js on your computer, and installed the packages "npx" & "create-react-app" to your global node_modules. This will reduce you having to re-install npx and create-react-app whenever you want to make a new React.js project.

### Creating the project
Open terminal in **Administrator mode** - otherwise, installation may error.

Run `cd C:/Users/User/Desktop/LearnReact` to go to your "LearnReact" folder on your Desktop.
Create the project like so: `npx create-react-app .` - **Note** the . is creating the project in the source folder (LearnReact); replacing this with a name, "MyProject", will create a folder called "MyProject" as the source of the project.

**Useful external packages**
Once installation is done, run the following:
* `npm i nodemon` - This installs nodemon, a module restarting your program every time you save a file; making development much easier.
* `npm i --save-dev @types/react @types/react-dom` - This installs the type definitions for the "react" and "react-dom" module, that installed when you ran the npx create-react-app command. This is so you can read the "internal documentation" / type definitions when coding, so you know what types you're working with.

**Modifying the npm start command**
Inside your LearnReact folder, there is now a package.json file. It will have a section like this:
```json
"scripts": {
    "start": "react-scripts start",
    "build": "react-scripts build",
    "test": "react-scripts test",
    "eject": "react-scripts eject"
}
```
Edit the **start** property to
```json
"scripts": {
    "start": "react-scripts start ; nodemon index.js",
    "build": "react-scripts build",
    "test": "react-scripts test",
    "eject": "react-scripts eject"
}
```
This is so nodemon starts when the React project starts, so nodemon actually works, and we didn't install it for no reason.

## Starting the project
To start the project, run `npm start` in a terminal, and it should magically open a browser for you with some boilercode generated from the npx create-react-app command.

## React hooks
A hook is a method, that handles "side-effects", which can be used to rerender/calculate values from the code into the website/DOM

### useState
Handles reactive data, that when changed, causes re-render.
useState returns an array, which by convention is handled like so:

```js
const [value, setValue] = useState(0);
```
Here, a value initialized with 0 is constructed, along with a setValue method, used to set the value varaible to another value.

setValue is used like so:
```js

//Direct state change
setValue(1); //Sets the value of "value" to 1

//Using previous value
setValue(preValue => preValue + 1); //Since state is updated asyncronously, using the callback version of setValue is safer than direct referring to the value variable.
```

**Example**
```js
import React, { useState } from 'react';

export default function MyComponent(props) {
   const [count, setCount] = useState(0);

   return (
      <div>
         <p>{count}</p>
         <button onClick={() => setCount(preCount => preCount + 1)}>Increment</button>
      </div>
   );
}
```

### useRef
Reference to an HTML element or an immutable object. useRef **does not** trigger a re-render.
Just like setState, useRef takes an argument as its default value, and retruns an object with a `.current` property, which is the current value the variable is referencing.

**Example**
Click count that doesn't trigger a render
```js
import React, { useRef } from 'react';

export default function MyComponent(props) {
    const count = useRef(0);

    return (
        <button onClick={() => count.current++}>Click me to add to the count!</button>
    )
}
```
However, since useRef doesn't trigger a re-render, you will never be able to see that your count changes, so the example is a little strange..

Reference HTML element
```js
import React, { useRef } from 'react';

export default function LoginExample(props) {
    const usernameElement = useRef(null);
    const passwordElement = useRef(null);

    function onLoginSubmit() {
        //Stupid fancy way to get the value from the referenced inputs.
        //An array consisting of the usernameElement input and passwordElement input
        //Both are inputs, which means the text the user entered is stored in the <Input>.value property
        //However since the array is consiting of useRef variables, we first need to use its .current, then we're able to use the .value property
        //So a new array is returned, which is what is destructured into a username & password variable.
        const [username, password] = [usernameElement, passwordElement].map(el => el.current.value);

        if (!username || !password) { //One of the inputs are blank or empty
            alert('Please fill in the login credentials!');
            return usernameElement.current.focus(); //Focuses the username input element
        }

        //...Handle login logic
    }

    return (
        <>
            <input type="text" ref={usernameElement} placeholder="Enter username">
            <input type="password" ref={passwordElement} placeholder="Enter password">
            <button onClick={onLoginSubmit}>Login</button>
        </>
    );
}
```

### useEffect
Methods to handle the component's lifecycle events: What should be run when the component is displayed? updated? destroyed?
useEffect accepts a callback function as the first argument, which will run when the component is displayed first time, and updated. If a function is returned from the callback, it will run that function when the component is destroyed.
useEffect accepts an array of "dependencies" as the second argument. Every time an item in the array changes, the first argument callback runs.

useEffect is used like so:
```js
//This useEffect callback will run each time the count property is changed. 
useEffect(() => {
   //Anything here will run when the component is displayed first time, or the one of the dependencies' array-items are updated
   console.log('Updated!');

   //This callback will run, when the component is removed from the DOM
   return () => console.log('Removed');
}, [count]);
```

**Example**
```js
import React, { useState, useEffect } from 'react';

export default function MyComponent(props) {
   const [count, setCount] = useState(0);

   //Will run when component is initialized
   useEffect(() => {
      console.log("I'm initialized!");
   }, []); //Array is empty, so callback will never be run again, unless a new component is created

   //Will run everytime count is updated
   useEffect(() => {
      console.log('The count property is updated!');
      return () => console.log('Component is removed');
   }, [count]);

   //Will run each component render
   useEffect(() => {
      console.log('Rerendered!');
   }); //Notice no dependencies - not even an array!

   return (
      <button onClick={() => setCount(preCount => preCount + 1)}>Number is {count}.</button>
   );
}
```

### useContext
Data that multiple components should possess; better than passing the same user object as props to nested components.
useContext usually has its own ContextProvider file, so you can import the component context for an easier experience with useContext. This is with help of the createContext method.
Once you have sat up the provider, you essentially only need to use its .Provider *once*, to give all nested components access to the context's data.

createContext accepts an initial value - like setState does.
createContext returns a Context object, which is typically used like so:

```js
const CountContext = createContext(0);
```

However, as stated, most prefer to have context's in seperate files, and create ContextProvider components, to have an easier experience with the context, thanks to createContext.
With this method, you can also use the setState hook to also provide setCount.
```js
export const CountContext = createContext(0);

export default function CountContextProvider(props) {
   const value = useContext(CountContext); //Get the current value of the CountContext object

   //Return JSX providing the CountContext value
   return (
      <CountContext.Provider value={value}> 
         {props.children} //IMPORTANT! Remember to render the props.children, otherwise this component is useless!
      </CountContext.Provider>
   );
}
```
With this code, you can now import CountContext from the ContextProvider file, and get the value, just as the above code does on line 4.
However, we cannot modify that value at all. To do so, we would need another hook to handle that.

This is where some prefer to create their own hooks. This is to have an even easier time with their context, and keep any context modifications within the context file.
```js
const CountContext = createContext(); //Note that CountContext no longer needs to be exported, and no longer needs a default value
const AddCountContext = createContext() 

export function useCount() {
    //Now you just need to import useCountContext, instead of importing both CountContext and useContext
   return useContext(CountContext); //Returns the value of CountContext (0)
}

//Importing useAddCount and calling to a variable, will return the addValue function defined further down, as the AddCountContext.Provider's value is the addValue function.
export function useAddCount() {
   return useContext(AddCountContext);
}

export default function CountContextProvider(props) {
    const [value, setValue] = useState(0); //Using useState here, we can now set the default value of value in the useState arguments to get the value, while also getting a way to update that value

    function addValue(addition) {
        return setValue(preValue => preValue + addition);
    }

    return (
        <CountContext.Provider value={value}>
            <AddCountContext.Provider value={addValue}>
                {props.children}
            </AddCountContext.Provider>
        </CountContext.Provider>
    );
}
```

**Example**
__CountContextProvider.js__
```js
import React, { useContext, createContext, useState } from 'react';

const CountContext = createContext();
const AddCountContext = createContext();
const RemoveCountContext = createContext();

//Per convention, all hooks must start with "use"

export function useCount() {
    return useContext(CountContext);
}
export function useAddCount() {
    return useContext(AddCountContext);
}
export function useRemoveCount() {
    return useContext(RemoveCountContext);
}

//Notice no "props" in arguments, but a "destructured" props, revealing the children as a stand-alone variable
export default function CountContextProvider({ children }) {
    const [count, setCount] = useState(0);

    function addCount(addition) {
        return setCount(preCount => preCount + addition);
    }
    function removeCount(subtraction) {
        return setCount(preCount => preCount - substraction);
    }

    return (
        <CountContext.Provider value={count}>
            <AddCountContext.Provider value={addCount}>
                <RemoveCountContext.Provider value={removeCount}>
                    {children}
                </RemoveCountContext.Provider>
            </AddCountContext.Provider>
        </CountContext.Provider>
    );
}
```
__App.js__
```js
import React from 'react';
import CountContextProvider from './CountContextProvider';
import MyComponent from './MyComponent';

export default function App(props) {
    return (
        <CountContextProvider>
            <MyComponent />
        </CountContextProvider>
    );
}
```
__MyComponent.js__
```js
import React from 'react';
import { useCount, useAddCount, useRemoveCount } from './CountContextProvider';

export default function MyComponent(props) {
    const count = useCount();
    const addValueToCount = useAddCount();
    const removeValueFromCount = useRemoveCount();

    return (
        <>
            <p>Count value: {count}</p>
            <button onClick={() => addValueToCount(1)}>Add 1</button>
            <button onClick={() => removeValueFromCount(1)}>Remove 1</button>
        </>
    );
}
```

### useReducer
All-mighty handler for a property.
useReducer is primarily used for managing state, if you need to change your state more than twice, or if your component grows too much, that it gets confusing to read with all kinds of state variables being modified with different functions.

useReducer takes in a callback, that it will call, once you use its `dispatch` method, it returns. Like most other hooks, it also takes in an initial/default value for the state.
useReducer returns an array, closely like setState, where the first element is the value, and the second is a function, however this function is not for setting the state, but to dispatch an operation type to your callback function.

useReducer is typically used like so:
```js
function modifyCount(count, action) {
    //action.type is convention, but you can ofcouse change that to your liking
    switch (action.type) {
        //Instead of hardcoded 'increment' & 'decrement', it's a good idea to make a constant "enum", to avoid silly spelling mistakes
        case 'increment': return count + 1;
        case 'decrement': return count - 1;
        default: return count;
    }
}

//dispatch is convention name, count, modifyCount and default value names are all up to you
const [count, dispatch] = useReducer(modifyCount, 0);
```

**Example**
```js
import React, { useReducer, useRef } from 'react';

const REDUCER_COUNT {
    INCREMENT: '+',
    DECREMENT: '-',
    MULTIPLY: '*',
    DIVIDE: '/',
    POWER: '^'
}

export default function MyComponent(props) {
    //Destructuring action as it makes reading easier
    //Payload is name by convention, and used to pass other values to help the dispatch
    function modifyCount(count, { type, payload }) {
        switch (type) {
            case REDUCER_COUNT.INCREMENT: return count + payload.value;
            case REDUCER_COUNT.DECREMENT: return count - payload.value;
            case REDUCER_COUNT.MULTIPLY: return count * payload.value;
            case REDUCER_COUNT.DIVIDE: return Math.round(count / payload.value);
            case REDUCER_COUNT.POWER: return Math.round(Math.pow(count, payload.value));
            default: return count;
        }
    }

    const [count, dispatch] = useReducer(modifyCount, 0);
    //Using ref to easily reference the HTML element in the calculate function
    const modificationType = useRef(null);
    const modify = useRef(null);

    function calculate() {
        dispatch({ type: modificationType.current.value, payload: { value: modify.current.value } });
    }

    return (
        <>
            <input type="number" id="count" value={count} readonly="readonly">
            <input type="list" id="modification-type" ref={modificationType}>
            //Dynamically inserts options from the REDUCER_COUNT object
            <datalist id="modification-types">
                {Object.keys(REDUCER_COUNT).map(prop => (
                    <option value={REDUCER_COUNT[prop]}>
                ))}
            </datalist>
            <input type="number" id="modify" ref={modify}>
            <button onClick={calculate}>Calculate</button>
        </>
    );
}
```


### useMemo
useMemo (useMemoization) is used for saving computed values on re-render. This means, instead of re-computing a value that takes a long time to compute, and you notice is hurting 
performance, it's recommended to use the useMemo hook, as useMemo is "saving" the computed value. It's kinda like caching a value.

useMemo takes a callback argument that expects the computed value, and an argument that expects an array of dependencies for when a state has changed (like useEffect).
useMemo returns the computed value.

If you experience strange behavior with your useEffect hook, it's usually because once a state has been modified, and the component re-renders, the useEffect will be re-run, *even* if you set its dependencies to be another state property - this is also a reason to use the useMemo hook, so that you're ensured that your useEffect hook only gets called, once your state changes!

**Example**
```js
import React, { useMemo } from 'react';

export default function Pokemon({ pokemonName }) {
    const pokemon = useMemo(async () => {
        //Fetching an API can sometimes be slow!
        const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonName}`);
        return JSON.parse(response.data);
    }, [pokemonName]);

    return (
        <div name={pokemon.name}>
            <h3>{pokemon.name}</h3>
            <img src={pokemon.sprites['front_default']} />
            <div class="pokemon-types">
                {pokemon.types.map(({ type }) => (
                    <p>{type.name}</p>
                ))}
            </div>
        </div>
    )
}
```

### useCallback
In some cases, you also want to cache functions, instead of re-computing them, like useMemo above.
If you have a big function, or a function that gets passed down to multiple children, grandchildren, etc., it may be a good idea to use the useCallback hook.
useCallback is especially used when items in an array are all using one function.

Just like useMemo, if you also experience strange behavior with useEffect for the functions here, it's the same exact reason - the function is being re-created each render, and may hurt performance, and will also cause re-renders of the component's children.

The biggest difference between useMemo and useCallback, is that useMemo returns the retrun value of the callback provided in the useMemo hook, whereas in useCallback, it returns the callback that was given in the useCallback hook.

**Example**
```js
import React, { useRef, useCallback } from 'react';

export default function Phonebook() {
    const countryCode = useRef(null);
    const phoneNumber = useRef(null);

    const getPhoneNumber = useCallback((countryCode, phoneNumber) => {
        const response = await fetch(`https://somephonecodeswebsite.com/countries`);
        const phoneCodes = JSON.parse(response.data);
        const phoneCode = phoneCodes.get(countryCode);
        return `${phoneCode} ${phoneNumber}`
    });

    return (
        <>
            <label> Country Code
                <input type="text" ref={countryCode}>
            </label>
            <label> Phone Number
                <input type="tel" ref={phoneNumber}>
            </label>
            <button onClick={() => alert(getPhoneNumber(countryCode.value, phoneNumber.value))}>
        </>
    )
}
```

### useImperativeHandle
If you're making a library for React.js or just want to modify something for the "public", useImperativeHandle is your hook.
You can essentially modify something using forwardRef a DOM reference, then edit an event, so you have full control over what others are doing with your component elements.
This is of course partnering with the useRef hook.
Despite it being rare, that someone would find a need for this hook, it does exist and can be used.

**Example**
```js
import React, { useState, forwardRef, useRef, useImperativeHandle } from 'react';
import fs from 'fs';

export default async function CookieClicker(props) {
    const clicker = useRef(null);
    const [clickValue, setClickValue] = useState(0);
    if (!fs.fileExists('../cookielog.txt')) {
        await fs.writeFile('../cookielog.txt', '', null);
    }

    forwardRef(clicker, () => ({
        click: () => {
            clicker.current.click();
            fs.appendFile('../cookielog.txt', `${new Date().toTimeString()} | Clicked: ${clickValue}`)
        }
    }));

    //When component is removed from DOM
    useEffect(() => {
        return async () => {
            if (!fs.fileExists('../cookiescore.txt')) {
                await fs.writeFile('../cookiescore.txt', '');
            }

            fs.appendFile('../cookiescore.txt', `${new Date().toLocaleDateString()}, ${new Date().toLocaleTimeString()}: HIGHSCORE: ${clickValue}`)
        }
    }, []);

    return (
        <>
            <p>{clickValue}</p>
            <button ref={clicker} onClick={() => setClickValue(preValue => preValue + 1)}>
        </>
    );
}
```


### useLayoutEffect
useLayoutEffect works just like useEffect, the difference is, that useLayoutEffect will run *before* the state updates.
This can be used to calculate stuff such as scroll position, before the DOM is visually updated.

Just like useEffect, the first argument is a callback to run, and as second argument, it takes in an array of dependencies

**Example**
```js
import React, { useRef, useLayoutEffect } from 'react';

export default function MyComponent(props) {
    const button = useRef(null);

    useLayoutEffect(() => {
        const rect = button.current.getBoundingClientRect();

        console.log(box.height);
    });

    return (
        <button ref={button}>I will log box height</button>
    );
}
```

### useDebugValue
When making your own hook, useDebugValue can tell you which hooks went into place, when running your custom hook.
This can be useful in debugging, using the React Dev tools.

You would insert the useDebugValue in your custom hook, to modify the properties displayed in the Dev tools

**Example**
```js
import React, { useDebugValue, useState, useMemo } from 'react'; 

function usePokemon(name) {
    const pokemon = useMemo(async () => {
        const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${name}`);
        return JSON.parse(response.data);
    }, [name]);

    //Will set the value of pokemon to "loading" until the memo is done loading
    useDebugValue(pokemon ?? 'loading...');

    return pokemon;
}

export default function Pokemon({ name }) {
    const pokemon = usePokemon(name);

    return (
        <p>{pokemon.name}</p>
    );
}
```